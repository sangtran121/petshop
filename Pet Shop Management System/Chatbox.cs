using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // Đảm bảo đã cài đặt Newtonsoft.Json 13.0.3

namespace Pet_Shop_Management_System
{
    public partial class Chatbox : Form
    {
        private readonly string apiKey;
        private readonly HttpClient client = new HttpClient();

        public Chatbox()
        {
            InitializeComponent();
            try
            {
                // Đọc trực tiếp và loại bỏ khoảng trắng thừa
                apiKey = File.ReadAllText("apikey.txt").Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file apikey.txt: " + ex.Message);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtQuestion.Text;
            if (string.IsNullOrWhiteSpace(userMessage)) return;

            AppendMessage("Bạn: " + userMessage);
            txtQuestion.Clear();
            AppendMessage("Chatbot đang trả lời...");

            string response = await GetGeminiResponse(userMessage);
            AppendMessage("Chatbot: " + response);
        }

        private async Task<string> GetGeminiResponse(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(apiKey)) return "Lỗi: Không tìm thấy API Key.";

                string model = "gemini-2.5-flash";  // hoặc gemini-1.5-flash
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";

                var requestBody = new
                {
                    contents = new[] {
                new {
                    parts = new[] { new { text = message } }
                }
            },
                    // Có thể thêm generationConfig nếu muốn
                    // generationConfig = new { temperature = 0.7, maxOutputTokens = 800 }
                };

                string jsonPayload = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    dynamic json = JsonConvert.DeserializeObject(responseString);
                    return json.candidates[0].content.parts[0].text?.ToString() ?? "Không có phản hồi.";
                }
                else
                {
                    return $"Lỗi API ({response.StatusCode}): {responseString}";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối: " + ex.Message;
            }
        }

        private void AppendMessage(string message)
        {
            rtbChatHistory.AppendText(message + Environment.NewLine);
            rtbChatHistory.ScrollToCaret();
        }
    }
}