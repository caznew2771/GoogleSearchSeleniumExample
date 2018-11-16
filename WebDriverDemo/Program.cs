namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string searchTerm = "pluralsight";

            SearchGoogle(searchTerm);
        }

        private static void SearchGoogle(string searchTerm)
        {
            Google _startPage = new Google(searchTerm);

            _startPage.ClickOnPrivacyReminder();
            _startPage.SubmitSearchCondition(searchTerm);
            _startPage.LocateLink();

            _startPage.LocateAllImages();
            string thatContainsLinkText = "Pluralsight";

            _startPage.ClickFirstImage(thatContainsLinkText);
        }
    }
}
