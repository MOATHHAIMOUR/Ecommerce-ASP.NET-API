namespace Ecommerce.Api.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// Build a Dictionary from searchText
        /// </summary>
        /// <param name="searchText">Name Moath, Age 14 or Name ASC, Age DESC</param>
        /// <returns>Dictionary that stores theses information as key value pair</returns>
        public static Dictionary<string,string> BuildDic(string searchText)
        {
            Dictionary<string,string> dic = [];

            string[] keysPerValues = searchText.Trim().Split(',');
            
            foreach (string key in keysPerValues)
            {
                string[] keyPerValue = key.Split(':');
                dic.Add(keyPerValue[0], keyPerValue[1]); 
            }
         
            return dic;
        }

    }
}
