using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Dapper;
using System.Xml.Serialization;

namespace Translator
{

    // data source=localhost;database=YZ_AuthCenter;user id=sa;password=yzw@123;Timeout=30;
    public partial class Form1 : Form
    {
        /// <summary>
        /// 翻译类别
        /// </summary>
        private TranslationCategory translationCategory;
        /// <summary>
        /// 翻译工具
        /// </summary>
        private TranslationMethods translationMethods;

        private string cookie;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(TranstalorHelper.Transtalor(""));
            try
            {
                string cookie = tbCookie_File.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                }
                tbResult.Text = TranstalorHelper.TranstaleByBing(tbQuery.Text, cookie);

            }
            catch (Exception ex)
            {
                tbResult.Text = "error:  " + ex.ToString();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  textBox2.Text= TranstalorHelper.TranstalorByYouDao(textBox1.Text);

            tbResult.Text = TranstalorHelper.TranstaleByYouDaoAPI(tbQuery.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// XML文件翻译(Bing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            cookie = tbCookie_File.Text.Trim();
            if (string.IsNullOrWhiteSpace(cookie))
            {
                MessageBox.Show("cookie不能为空");
                return;
            }
            translationMethods = TranslationMethods.Bing;
            translationCategory = TranslationCategory.Config;
            Translator(textBox3.Text);
        }

        /// <summary>
        /// JSON文件翻译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            cookie = tbCookie_File.Text.Trim();
            if (string.IsNullOrWhiteSpace(cookie))
            {
                MessageBox.Show("cookie不能为空");
                return;
            }
            translationMethods = TranslationMethods.Bing;
            translationCategory = TranslationCategory.JSON;
            Translator(textBox3.Text);
        }


        /// <summary>
        /// 有道XML翻译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            translationMethods = TranslationMethods.YouDao;
            translationCategory = TranslationCategory.Config;
            Translator(textBox3.Text);

        }


        /// <summary>
        /// JSON文件翻译(YouDao)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            translationMethods = TranslationMethods.YouDao;
            translationCategory = TranslationCategory.JSON;
            Translator(textBox3.Text);
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            try
            {
                cookie = tbCookie_File.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(textBox3.Text);

                //找到该目录下的文件  
                FileInfo[] fi = dir.GetFiles();
                foreach (FileInfo f in fi)
                {
                    if (f.Extension.Replace(".", "").ToLower().Equals(TranslationCategory.Config.ToString().ToLower()))
                    {
                        var xmlData = LoadFromXml<List<B2BMenuModel>>(f.FullName);

                        foreach (var item in xmlData)
                        {
                            if (!string.IsNullOrWhiteSpace(item.MenuName))
                            {
                                string resultMenuNameVal = TranstalorHelper.TranstaleByBing(item.MenuName.StartsWith("E-") ? item.MenuName.Replace("E-", "") : item.MenuName, cookie);
                                var menuNameData = JsonDeserializeFixed<BingResultData>(resultMenuNameVal);
                                //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                                item.MenuName = menuNameData.items[0].text;
                            }

                            if (!string.IsNullOrWhiteSpace(item.ShortName))
                            {
                                string resultShortNameVal = TranstalorHelper.TranstaleByBing(item.ShortName.StartsWith("E-") ? item.ShortName.Replace("E-", "") : item.ShortName, cookie);
                                var shortNameData = JsonDeserializeFixed<BingResultData>(resultShortNameVal);
                                //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                                item.ShortName = shortNameData.items[0].text;

                            }
                        }
                        SaveToXml(f.FullName, xmlData);
                    }
                }

                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// SEO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSEO_Click(object sender, EventArgs e)
        {
            try
            {
                cookie = tbCookie_File.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(textBox3.Text);

                //找到该目录下的文件  
                FileInfo[] fi = dir.GetFiles();
                foreach (FileInfo f in fi)
                {
                    if (f.Extension.Replace(".", "").ToLower().Equals(TranslationCategory.Config.ToString().ToLower()))
                    {
                        var xmlData = LoadFromXml<PageSEOConfig>(f.FullName);

                        if (!string.IsNullOrWhiteSpace(xmlData.SuffixTitle))
                        {
                            string resultVal = TranstalorHelper.TranstaleByBing(xmlData.SuffixTitle.StartsWith("E-") ? xmlData.SuffixTitle.Replace("E-", "") : xmlData.SuffixTitle, cookie);
                            var resultData = JsonDeserializeFixed<BingResultData>(resultVal);
                            //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                            xmlData.SuffixTitle = resultData.items[0].text;
                        }

                        foreach (var item in xmlData.CustomList)
                        {
                            if (!string.IsNullOrWhiteSpace(item.Title))
                            {
                                string resultTitleVal = TranstalorHelper.TranstaleByBing(item.Title.StartsWith("E-") ? item.Title.Replace("E-", "") : item.Title, cookie);
                                var titleData = JsonDeserializeFixed<BingResultData>(resultTitleVal);
                                //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                                item.Title = titleData.items[0].text;
                            }

                            if (!string.IsNullOrWhiteSpace(item.Keywords))
                            {
                                string resultKeywordsVal = TranstalorHelper.TranstaleByBing(item.Keywords.StartsWith("E-") ? item.Keywords.Replace("E-", "") : item.Keywords, cookie);
                                var keywordsData = JsonDeserializeFixed<BingResultData>(resultKeywordsVal);
                                //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                                item.Keywords = keywordsData.items[0].text;
                            }
                            if (!string.IsNullOrWhiteSpace(item.Description))
                            {
                                string resultDescriptionVal = TranstalorHelper.TranstaleByBing(item.Description.StartsWith("E-") ? item.Description.Replace("E-", "") : item.Description, cookie);
                                var descriptionData = JsonDeserializeFixed<BingResultData>(resultDescriptionVal);
                                //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                                item.Description = descriptionData.items[0].text;
                            }
                        }
                        SaveToXml(f.FullName, xmlData);
                    }
                }

                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Translator(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                Run(dir);
                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Run(DirectoryInfo directoryInfo)
        {
            //找到该目录下的文件  
            FileInfo[] fi = directoryInfo.GetFiles();
            foreach (FileInfo f in fi)
            {

                if (f.Extension.Replace(".", "").ToLower().Equals(translationCategory.ToString().ToLower()))
                {
                    Debug.WriteLine(f.FullName);
                    var data = GetData(f.FullName);
                    if (data.Count > 0)
                    {
                        string configContent = "";
                        if (translationCategory == TranslationCategory.Config)
                        {
                            configContent = GetXMLConfigContent(data);
                        }
                        else if (translationCategory == TranslationCategory.JSON)
                        {
                            configContent = GetJsonConfigContent(data);
                        }

                        if (string.IsNullOrWhiteSpace(configContent))
                        {
                            continue;
                        }
                        File.WriteAllText(Path.Combine(directoryInfo.FullName, f.Name), configContent);
                    }

                }
            }

            //获取该目录下的文件夹，递归处理
            DirectoryInfo[] di = directoryInfo.GetDirectories();
            foreach (DirectoryInfo item in di)
            {
                Run(item);
            }
        }


        private Dictionary<string, string> GetData(string path)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, string> result = new Dictionary<string, string>();


            if (translationCategory == TranslationCategory.Config)
            {
                XElement doc = XElement.Load(path);
                dic = parseXml(doc);
            }
            else if (translationCategory == TranslationCategory.JSON)
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }
            }

            //转换
            string val = "";
            string resultVal = "";
            foreach (var item in dic)
            {

                //todo:临时屏蔽，正式使用时放开，不然会重复翻译

                if (item.Value.StartsWith("E-"))
                {
                    val = item.Value.Replace("E-", "");
                }
                else
                {//已翻译过
                    if (!result.ContainsKey(item.Key))
                    {
                        result.Add(item.Key, item.Value);
                    }
                    continue;
                }

                //todo:屏蔽
                // val = item.Key;
                //  Debug.WriteLine(val);

                if (translationMethods == TranslationMethods.YouDao)
                {
                    try
                    {
                        resultVal = TranstalorHelper.TranstaleByYouDaoAPI(val);

                        var data = JsonDeserializeFixed<YouDaoResultData>(resultVal);
                        // { "tSpeakUrl":"https://dict.youdao.com/dictvoice?audio=You+are+my+little+apple&le=auto&channel=5c11890b3dee46be&rate=4","query":"你是我的小苹果","translation":["You are my little apple"],"errorCode":"0","basic":{"explains":["You are my little apple."]},"speakUrl":"https://dict.youdao.com/dictvoice?audio=%E4%BD%A0%E6%98%AF%E6%88%91%E7%9A%84%E5%B0%8F%E8%8B%B9%E6%9E%9C&le=auto&channel=5c11890b3dee46be&rate=4"}
                        if (!result.ContainsKey(item.Key))
                        {
                            result.Add(item.Key, data.translation[0]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("-------异常：" + val);
                    }
                }
                else if (translationMethods == TranslationMethods.Bing)
                {
                    try
                    {
                        resultVal = TranstalorHelper.TranstaleByBing(val, cookie);
                        //if (string.IsNullOrEmpty(resultVal))
                        //{
                        //    continue;
                        //}
                        var data = JsonDeserializeFixed<BingResultData>(resultVal);
                        //{"from":"zh-CHS","to":"en","items":[{"id":"-17855184818","text":"Please enter the username you want to retrieve","wordAlignment":""}]}
                        if (!result.ContainsKey(item.Key))
                        {
                            result.Add(item.Key, data.items[0].text);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("-------异常：" + val);
                    }

                }
                else if (translationMethods == TranslationMethods.Google)
                {

                }


            }

            return result;
        }

        private static Dictionary<string, string> parseXml(XElement doc)
        {
            Dictionary<string, string> rst = new Dictionary<string, string>();

            foreach (var x in doc.Descendants("Message"))
            {
                if (x.Attribute("name") == null || x.Attribute("name").Value == null || x.Attribute("name").Value.Trim().Length <= 0)
                {
                    throw new ApplicationException("There are some 'Message' node without attribute 'name' in the TextResource config file, please check it!");
                }
                string name = x.Attribute("name").Value.Trim().ToUpper();
                if (rst.ContainsKey(name))
                {
                    throw new ApplicationException("Duplicated value '" + x.Attribute("name").Value.Trim() + "' of attribute 'name' in 'Message' node in the TextResource config file, please check it (ex: ignore case)!");
                }
                rst.Add(name, x.Value);
            }
            return rst;
        }

        public static T LoadFromXml<T>(string filePath)
        {
            FileStream fs = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return (T)serializer.Deserialize(fs);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        public static void SaveToXml(string filePath, object data)
        {
            FileStream fs = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                serializer.Serialize(fs, data);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        private string GetXMLConfigContent(Dictionary<string, string> dic)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("Text"));
            foreach (var name in dic)
            {
                XmlElement el = (XmlElement)root.AppendChild(doc.CreateElement("Message"));
                el.SetAttribute("name", name.Key);
                el.AppendChild(doc.CreateElement("Value")).InnerText = name.Value;
            }
            //FormatXml
            XDocument xDoc = XDocument.Parse(doc.OuterXml);
            xDoc.Declaration = new XDeclaration("1.0", "utf-8", null);
            return xDoc.Declaration.ToString() + Environment.NewLine + xDoc.ToString();
        }

        private string GetJsonConfigContent(Dictionary<string, string> dic)
        {
            return JsonConvert.SerializeObject(dic);
        }


        private T JsonDeserializeFixed<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void btnGoogle_Click(object sender, EventArgs e)
        {
            tbResult.Text = TranstalorHelper.TranstaleByGoogle(tbQuery.Text.Trim());
        }





        #region DB


        #region 机构

        private void btnSystemOrganization_Click(object sender, EventArgs e)
        {
            try
            {
                #region MyRegion

                cookie = tbCookie_DB.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                    return;
                }
                if (tbDBConfig.Text.Trim() == "")
                {
                    MessageBox.Show("数据库地址不能为空！");
                    return;
                }
                //        data source=localhost;database=YZ_AuthCenter;user id=sa;password=yzw@123;
                string insertSql = @"INSERT INTO [YZ_AuthCenter].[dbo].[SystemOrganization_Resource]
                                   ([SystemOrganizationSysNo]
                                   ,[LanguageCode]
                                   ,[OrganizationName]
                                   ,[OrganizationFullName]
                                   ,[InUserSysNo]
                                   ,[InUserName]
                                   ,[InDate]
                                   ,[EditUserSysNo]
                                   ,[EditUserName]
                                   ,[EditDate])
                             VALUES
                                   (@SystemOrganizationSysNo
                                   , @LanguageCode
                                   , @OrganizationName
                                   , @OrganizationFullName
                                   , @InUserSysNo
                                   , @InUserName
                                   , @InDate
                                   , @EditUserSysNo
                                   , @EditUserName
                                   , @EditDate)";
                List<BingRequestData> bingReqOrgNameDataList = new List<BingRequestData>();
                List<BingRequestData> bingReqOrgFNameDataList = new List<BingRequestData>();

                #endregion


                using (IDbConnection conn = new SqlConnection(tbDBConfig.Text.Trim()))
                {
                    conn.Open();
                    var data = conn.Query<SystemOrganization>(@"
                     SELECT A.[SysNo]
                          ,A.[OrganizationName]
                          ,A.OrganizationFullName
                      FROM [YZ_AuthCenter].[dbo].[SystemOrganization] A
                      WHERE NOT EXISTS(
                      SELECT TOP 1 
                                 1
			                     FROM [YZ_AuthCenter].[dbo].[SystemOrganization_Resource] B WHERE 
			                     A.SysNo=B.SystemOrganizationSysNo)
                   
                        "
                    );

                    foreach (var item in data)
                    {

                        bingReqOrgNameDataList.Add(new BingRequestData() { id = item.SysNo, text = item.OrganizationName });
                        bingReqOrgFNameDataList.Add(new BingRequestData() { id = item.SysNo, text = item.OrganizationFullName });

                        //批量插入50条
                        //if (bingReqOrgNameDataList.Count == 50)
                        //{
                            InsertSystemOrganization_Resource(insertSql, bingReqOrgNameDataList, bingReqOrgFNameDataList, conn);

                            bingReqOrgNameDataList.Clear();
                            bingReqOrgFNameDataList.Clear();
                       // }

                    }

                    if (bingReqOrgNameDataList.Count() > 0)
                    {
                        InsertSystemOrganization_Resource(insertSql, bingReqOrgNameDataList, bingReqOrgFNameDataList, conn);
                    }

                }
                MessageBox.Show("成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertSystemOrganization_Resource(string insertSql, List<BingRequestData> bingReqOrgNameDataList, List<BingRequestData> bingReqOrgFNameDataList, IDbConnection conn)
        {
            List<SystemOrganization_Resource> systemOrganization_ResourceList = new List<SystemOrganization_Resource>();




            string resultVal = TranstalorHelper.TranstaleByYouDaoAPI(bingReqOrgNameDataList.First().text);
            var resultData = JsonDeserializeFixed<YouDaoResultData>(resultVal);



            string resultOrgFNameVal = TranstalorHelper.TranstaleByYouDaoAPI(bingReqOrgFNameDataList.First().text);
            var resultOrgFNameData = JsonDeserializeFixed<YouDaoResultData>(resultOrgFNameVal);

            systemOrganization_ResourceList.Add(new SystemOrganization_Resource()
            {

                LanguageCode = "en-us",
                EditDate = DateTime.Now,
                EditUserName = "AUTO",
                EditUserSysNo = 0,
                InDate = DateTime.Now,
                InUserName = "AUTO",
                InUserSysNo = 0,
                SystemOrganizationSysNo = bingReqOrgNameDataList.First().id,
                OrganizationName = resultData.translation.Count() > 0 ? resultData.translation[0] : resultData.web.Count() == 0 ? string.Empty : resultData.web[0].value[0],
                OrganizationFullName = resultOrgFNameData.translation.Count() > 0 ? resultOrgFNameData.translation[0] : resultOrgFNameData.web.Count() == 0 ? string.Empty : resultOrgFNameData.web[0].value[0]
            });





            //#region OrgName（bing翻译请求过多时，会被限制访问）

            //string bingReqOrgNameDataListStr = JsonConvert.SerializeObject(bingReqOrgNameDataList);
            //string resultOrgNameVal = TranstalorHelper.TranstaleByBing(bingReqOrgNameDataListStr, cookie, true);
            //var resultOrgNameData = JsonDeserializeFixed<BingResultData>(resultOrgNameVal);

            //foreach (var bingOrgNameDataItem in resultOrgNameData.items)
            //{
            //    systemOrganization_ResourceList.Add(
            //        new SystemOrganization_Resource()
            //        {
            //            LanguageCode = "en-us",
            //            EditDate = DateTime.Now,
            //            EditUserName = "AUTO",
            //            EditUserSysNo = 0,
            //            InDate = DateTime.Now,
            //            InUserName = "AUTO",
            //            InUserSysNo = 0,
            //            SystemOrganizationSysNo = int.Parse(bingOrgNameDataItem.id),
            //            OrganizationName = bingOrgNameDataItem.text
            //        });
            //};
            //#endregion

            //#region OrgFullName

            //string bingReqOrgFNameDataListStr = JsonConvert.SerializeObject(bingReqOrgFNameDataList);
            //string resultOrgFNameVal = TranstalorHelper.TranstaleByBing(bingReqOrgFNameDataListStr, cookie, true);
            //var resultOrgFNameData = JsonDeserializeFixed<BingResultData>(resultOrgFNameVal);

            //resultOrgFNameData.items.ForEach(m =>
            //{
            //    systemOrganization_ResourceList.Find(sr => sr.SystemOrganizationSysNo.Equals(int.Parse(m.id))).OrganizationFullName = m.text;
            //});
            //#endregion

            conn.Execute(insertSql, systemOrganization_ResourceList);
        }
        #endregion

        #region 区域

        private void btnSystemArea_Click(object sender, EventArgs e)
        {
            try
            {
                cookie = tbCookie_DB.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                }

                List<BingRequestData> bingRequestDataList = new List<BingRequestData>();
                //        data source=localhost;database=YZ_AuthCenter;user id=sa;password=yzw@123;
                string insertSql = @"INSERT INTO YZ_Operation.[dbo].[SystemArea_Resource]
                                   ([SystemAreaSysNo]
                                   ,[LanguageCode]
                                   ,[AreaName]
                                   ,[InUserSysNo]
                                   ,[InUserName]
                                   ,[InDate]
                                   ,[EditUserSysNo]
                                   ,[EditUserName]
                                   ,[EditDate])
                             VALUES
                                   ( @SystemAreaSysNo
                                   , @LanguageCode
                                   , @AreaName
                                   , @InUserSysNo
                                   , @InUserName
                                   , @InDate
                                   , @EditUserSysNo
                                   , @EditUserName
                                   , @EditDate)";
                if (tbDBConfig.Text.Trim() == "")
                {
                    MessageBox.Show("数据库地址不能为空！");
                    return;
                }
                using (IDbConnection conn = new SqlConnection(tbDBConfig.Text.Trim()))
                {
                    conn.Open();
                    var data = conn.Query<SystemArea>(@"
                     SELECT A.[SysNo]
                          ,A.[AreaName]
                      FROM [YZ_Operation].[dbo].[SystemArea] A
                      WHERE NOT EXISTS(
                      SELECT TOP 1 
                                 1
			                     FROM [YZ_Operation].[dbo].[SystemArea_Resource] B WHERE 
			                     A.SysNo=B.SystemAreaSysNo)"
                    );

                    foreach (var item in data)
                    {
                        bingRequestDataList.Add(new BingRequestData() { id = item.SysNo, text = item.AreaName });
                        //批量插入50条
                        if (bingRequestDataList.Count == 50)
                        {
                            InsertSysTemArea_Resource(bingRequestDataList, insertSql, conn);
                            bingRequestDataList.Clear();
                        }
                    }
                    if (bingRequestDataList.Count() > 0)
                    {
                        InsertSysTemArea_Resource(bingRequestDataList, insertSql, conn);
                    }
                }
                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertSysTemArea_Resource(List<BingRequestData> bingRequestDataList, string insertSql, IDbConnection conn)
        {
            List<SystemArea_Resource> systemArea_ResourceList = new List<SystemArea_Resource>();

            string bingRequestDataListStr = JsonConvert.SerializeObject(bingRequestDataList);
            string resultVal = TranstalorHelper.TranstaleByBing(bingRequestDataListStr, cookie, true);
            var resultData = JsonDeserializeFixed<BingResultData>(resultVal);
            foreach (var bingDataItem in resultData.items)
            {
                systemArea_ResourceList.Add(new SystemArea_Resource()
                {
                    AreaName = bingDataItem.text,
                    SystemAreaSysNo = int.Parse(bingDataItem.id),
                    LanguageCode = "en-us",
                    EditDate = DateTime.Now,
                    EditUserName = "AUTO",
                    EditUserSysNo = 0,
                    InDate = DateTime.Now,
                    InUserName = "AUTO",
                    InUserSysNo = 0
                });
            }
            conn.Execute(insertSql, systemArea_ResourceList);
        }


        private void btnSystemAreaByYouDao_Click(object sender, EventArgs e)
        {
            try
            {
                List<SystemArea_Resource> systemArea_ResourceList = new List<SystemArea_Resource>();

                string insertSql = @"INSERT INTO YZ_Operation.[dbo].[SystemArea_Resource]
                                   ([SystemAreaSysNo]
                                   ,[LanguageCode]
                                   ,[AreaName]
                                   ,[InUserSysNo]
                                   ,[InUserName]
                                   ,[InDate]
                                   ,[EditUserSysNo]
                                   ,[EditUserName]
                                   ,[EditDate])
                             VALUES
                                   ( @SystemAreaSysNo
                                   , @LanguageCode
                                   , @AreaName
                                   , @InUserSysNo
                                   , @InUserName
                                   , @InDate
                                   , @EditUserSysNo
                                   , @EditUserName
                                   , @EditDate)";
                if (tbDBConfig.Text.Trim() == "")
                {
                    MessageBox.Show("数据库地址不能为空！");
                    return;
                }
                using (IDbConnection conn = new SqlConnection(tbDBConfig.Text.Trim()))
                {
                    conn.Open();
                    var data = conn.Query<SystemArea>(@"
                     SELECT A.[SysNo]
                          ,A.[AreaName]
                      FROM [YZ_Operation].[dbo].[SystemArea] A
                      WHERE NOT EXISTS(
                      SELECT TOP 1 
                                 1
			                     FROM [YZ_Operation].[dbo].[SystemArea_Resource] B WHERE 
			                     A.SysNo=B.SystemAreaSysNo)"
                    );

                    foreach (var item in data)
                    {
                        string resultVal = TranstalorHelper.TranstaleByYouDaoAPI(item.AreaName);

                        Debug.WriteLine("原始值："+ item.AreaName);

                        Debug.WriteLine("翻译后值："+resultVal);
                        if (string.IsNullOrWhiteSpace(resultVal))
                        {
                            continue;
                        }

                        var resultData = JsonDeserializeFixed<YouDaoResultData>(resultVal);
                        // { "tSpeakUrl":"https://dict.youdao.com/dictvoice?audio=You+are+my+little+apple&le=auto&channel=5c11890b3dee46be&rate=4","query":"你是我的小苹果","translation":["You are my little apple"],"errorCode":"0","basic":{"explains":["You are my little apple."]},"speakUrl":"https://dict.youdao.com/dictvoice?audio=%E4%BD%A0%E6%98%AF%E6%88%91%E7%9A%84%E5%B0%8F%E8%8B%B9%E6%9E%9C&le=auto&channel=5c11890b3dee46be&rate=4"}

                        //原始值：铜鼓县(这种翻译没有标准结果，取web中value)
                        //翻译后值：{ "web":[{"value":["Tonggu County","Tonggu","Tonggu county"],"key":"铜鼓县"}],"query":"铜鼓县","errorCode":"0","speakUrl":"https://dict.youdao.com/dictvoice?audio=%E9%93%9C%E9%BC%93%E5%8E%BF&le=auto&channel=5c11890b3dee46be&rate=4"}

                        //原始值：赣县
                        //翻译后值：{ "tSpeakUrl":"https://dict.youdao.com/dictvoice?audio=county&le=auto&channel=5c11890b3dee46be&rate=4","web":[{"value":["Gan County","gan county","Ganxian"],"key":"赣县"},{"value":["Gan County"],"key":"家住赣县"}],"query":"赣县","translation":["county"],"errorCode":"0","basic":{"explains":["Ganxian County"]},"speakUrl":"https://dict.youdao.com/dictvoice?audio=%E8%B5%A3%E5%8E%BF&le=auto&channel=5c11890b3dee46be&rate=4"}


                       systemArea_ResourceList.Add(new SystemArea_Resource()
                        {
                            AreaName = resultData.translation.Count()>0?resultData.translation[0]:resultData.web.Count()==0?string.Empty: resultData.web[0].value[0],
                            SystemAreaSysNo = item.SysNo,
                            LanguageCode = "en-us",
                            EditDate = DateTime.Now,
                            EditUserName = "AUTO",
                            EditUserSysNo = 0,
                            InDate = DateTime.Now,
                            InUserName = "AUTO",
                            InUserSysNo = 0
                        });
                        if (systemArea_ResourceList.Count() == 50)
                        {
                            conn.Execute(insertSql, systemArea_ResourceList);
                            systemArea_ResourceList.Clear();
                        }
                    }
                    if (systemArea_ResourceList.Count() > 0)
                    {
                        conn.Execute(insertSql, systemArea_ResourceList);
                    }
                }
                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 投标状态

        private void btnBidTool_TenderBidStatusItem_Click(object sender, EventArgs e)
        {
            try
            {
                cookie = tbCookie_DB.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                }

                List<BingRequestData> bingRequestDataList = new List<BingRequestData>();
                string insertSql = @"INSERT INTO [YZ_Tender].[dbo].[BidTool_TenderBidStatusItem_Resource]
                                   ([BidTool_TenderBidStatusItemSysNo]
                                   ,[LanguageCode]
                                   ,[NoticeContent]
                                  )
                             VALUES
                                   (@BidTool_TenderBidStatusItemSysNo
                                   ,@LanguageCode
                                   ,@NoticeContent
                                   )";
                if (tbDBConfig.Text.Trim() == "")
                {
                    MessageBox.Show("数据库地址不能为空！");
                    return;
                }
                using (IDbConnection conn = new SqlConnection(tbDBConfig.Text.Trim()))
                {
                    conn.Open();
                    var data = conn.Query<BidTool_TenderBidStatusItem>(@"
                     SELECT A.SysNo,A.NoticeContent FROM [YZ_Tender].[dbo].[BidTool_TenderBidStatusItem] A
                        WHERE NOT EXISTS (
	                    SELECT TOP 1
	                               1
			                       FROM YZ_Tender.dbo.BidTool_TenderBidStatusItem_Resource B
			                       WHERE A.SysNo=b.BidTool_TenderBidStatusItemSysNo
	                    )
	                    AND A.NoticeContent NOT IN ('','bid_notice','bid_tender','adjustment_notice','result','resulted')"
                    );

                    foreach (var item in data)
                    {
                        bingRequestDataList.Add(new BingRequestData() { id = item.SysNo, text = item.NoticeContent });
                        //批量插入50条
                        if (bingRequestDataList.Count == 50)


                        {
                            InsertBidTool_TenderBidStatusItem_Resource(bingRequestDataList, insertSql, conn);
                            bingRequestDataList.Clear();
                        }
                    }
                    if (bingRequestDataList.Count() > 0)
                    {
                        InsertBidTool_TenderBidStatusItem_Resource(bingRequestDataList, insertSql, conn);
                    }
                }
                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertBidTool_TenderBidStatusItem_Resource(List<BingRequestData> bingRequestDataList, string insertSql, IDbConnection conn)
        {
            List<BidTool_TenderBidStatusItem_Resource> bidTool_TenderBidStatusItem_Resource = new List<BidTool_TenderBidStatusItem_Resource>();

            string bingRequestDataListStr = JsonConvert.SerializeObject(bingRequestDataList);
            string resultVal = TranstalorHelper.TranstaleByBing(bingRequestDataListStr, cookie, true);
            var resultData = JsonDeserializeFixed<BingResultData>(resultVal);
            foreach (var bingDataItem in resultData.items)
            {
                bidTool_TenderBidStatusItem_Resource.Add(new BidTool_TenderBidStatusItem_Resource()
                {
                    NoticeContent = bingDataItem.text,
                    BidTool_TenderBidStatusItemSysNo = int.Parse(bingDataItem.id),
                    LanguageCode = "en-us",
                    EditDate = DateTime.Now,
                    EditUserName = "AUTO",
                    EditUserSysNo = 0,
                    InDate = DateTime.Now,
                    InUserName = "AUTO",
                    InUserSysNo = 0
                });
            }
            conn.Execute(insertSql, bidTool_TenderBidStatusItem_Resource);
        }

        #endregion

        #region 品类

        private void btnSystemCategory_Click(object sender, EventArgs e)
        {
            try
            {
                cookie = tbCookie_DB.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                }

                List<BingRequestData> bingRequestDataList = new List<BingRequestData>();
                string insertSql = @"INSERT INTO [YZ_Operation].[dbo].[SystemCategory_Resource]
                                   ([SystemCategorySysNo]
                                   ,[LanguageCode]
                                   ,[CategoryName]
                                   ,[InUserSysNo]
                                   ,[InUserName]
                                   ,[InDate]
                                   ,[EditUserSysNo]
                                   ,[EditUserName]
                                   ,[EditDate])
                             VALUES
                                   (@SystemCategorySysNo
                                   ,@LanguageCode
                                   ,@CategoryName
                                   , @InUserSysNo
                                   , @InUserName
                                   , @InDate
                                   , @EditUserSysNo
                                   , @EditUserName
                                   , @EditDate)";
                if (tbDBConfig.Text.Trim() == "")
                {
                    MessageBox.Show("数据库地址不能为空！");
                    return;
                }
                using (IDbConnection conn = new SqlConnection(tbDBConfig.Text.Trim()))
                {
                    conn.Open();
                    var data = conn.Query<SystemCategory>(@"
                              SELECT A.SysNo,A.CategoryName FROM [YZ_Operation].[dbo].[SystemCategory] A
                                     WHERE NOT EXISTS
                                          (
	                                        SELECT TOP 1
	                                                   1
			                                           FROM [YZ_Operation].[dbo].[SystemCategory_Resource] B
			                                           WHERE A.SysNo=b.SystemCategorySysNo
	                                        )"
                    );

                    foreach (var item in data)
                    {
                        bingRequestDataList.Add(new BingRequestData() { id = item.SysNo, text = item.CategoryName });
                        //批量插入50条
                        if (bingRequestDataList.Count == 50)
                        {
                            InsertSystemCategory_Resource(bingRequestDataList, insertSql, conn);
                            bingRequestDataList.Clear();
                        }
                    }
                    if (bingRequestDataList.Count() > 0)
                    {
                        InsertSystemCategory_Resource(bingRequestDataList, insertSql, conn);
                    }
                }
                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertSystemCategory_Resource(List<BingRequestData> bingRequestDataList, string insertSql, IDbConnection conn)
        {
            List<SystemCategory_Resource> systemCategory_Resource = new List<SystemCategory_Resource>();

            string bingRequestDataListStr = JsonConvert.SerializeObject(bingRequestDataList);
            string resultVal = TranstalorHelper.TranstaleByBing(bingRequestDataListStr, cookie, true);
            var resultData = JsonDeserializeFixed<BingResultData>(resultVal);
            foreach (var bingDataItem in resultData.items)
            {
                systemCategory_Resource.Add(new SystemCategory_Resource()
                {
                    CategoryName = bingDataItem.text,
                    SystemCategorySysNo = int.Parse(bingDataItem.id),
                    LanguageCode = "en-us",
                    EditDate = DateTime.Now,
                    EditUserName = "AUTO",
                    EditUserSysNo = 0,
                    InDate = DateTime.Now,
                    InUserName = "AUTO",
                    InUserSysNo = 0
                });
            }
            conn.Execute(insertSql, systemCategory_Resource);
        }
        #endregion

        #region 供应商分类

        private void btnSupplierCategory_Click(object sender, EventArgs e)
        {
            try
            {
                cookie = tbCookie_DB.Text.Trim();
                if (string.IsNullOrWhiteSpace(cookie))
                {
                    MessageBox.Show("cookie不能为空");
                }

                List<BingRequestData> bingRequestDataList = new List<BingRequestData>();
                string insertSql = @"INSERT INTO  [YZ_Supplier].[dbo].[SupplierCategory_Resource]
                                   ([SupplierCategorySysNo]
                                   ,[LanguageCode]
                                   ,[CategoryName]
                                   ,[InUserSysNo]
                                   ,[InUserName]
                                   ,[InDate]
                                   ,[EditUserSysNo]
                                   ,[EditUserName]
                                   ,[EditDate])
                             VALUES
                                   (@SupplierCategorySysNo
                                   ,@LanguageCode
                                   ,@CategoryName
                                   ,@InUserSysNo
                                   ,@InUserName
                                   ,@InDate
                                   ,@EditUserSysNo
                                   ,@EditUserName
                                   ,@EditDate)";
                if (tbDBConfig.Text.Trim() == "")
                {
                    MessageBox.Show("数据库地址不能为空！");
                    return;
                }
                using (IDbConnection conn = new SqlConnection(tbDBConfig.Text.Trim()))
                {
                    conn.Open();
                    var data = conn.Query<SystemCategory>(@"
                              SELECT A.SysNo,A.CategoryName FROM [YZ_Supplier].[dbo].[SupplierCategory] A
                                     WHERE NOT EXISTS
                                          (
	                                        SELECT TOP 1
	                                                   1
			                                           FROM  [YZ_Supplier].[dbo].[SupplierCategory_Resource] B
			                                           WHERE A.SysNo=b.SupplierCategorySysNo
	                                        )"
                    );

                    foreach (var item in data)
                    {
                        bingRequestDataList.Add(new BingRequestData() { id = item.SysNo, text = item.CategoryName });
                        //批量插入50条
                        //if (bingRequestDataList.Count == 50)
                        //{
                            InsertSupplierCategory_Resource(bingRequestDataList, insertSql, conn);
                            bingRequestDataList.Clear();
                       // }
                    }
                    if (bingRequestDataList.Count() > 0)
                    {
                        InsertSupplierCategory_Resource(bingRequestDataList, insertSql, conn);
                    }
                }
                MessageBox.Show("成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertSupplierCategory_Resource(List<BingRequestData> bingRequestDataList, string insertSql, IDbConnection conn)
        {
            List<SupplierCategory_Resource> supplierCategory_Resource = new List<SupplierCategory_Resource>();

            string bingRequestDataListStr = JsonConvert.SerializeObject(bingRequestDataList);
            string resultVal = TranstalorHelper.TranstaleByBing(bingRequestDataListStr, cookie, true);
            var resultData = JsonDeserializeFixed<BingResultData>(resultVal);
            foreach (var bingDataItem in resultData.items)
            {
                if (bingDataItem.text.Length > 100)
                {

                }
                bingDataItem.text = bingDataItem.text.Length > 100 ? bingDataItem.text.Substring(0, 100) : bingDataItem.text;
               

                supplierCategory_Resource.Add(new SupplierCategory_Resource()
                {
                    CategoryName = bingDataItem.text,
                    SupplierCategorySysNo = int.Parse(bingDataItem.id),
                    LanguageCode = "en-us",
                    EditDate = DateTime.Now,
                    EditUserName = "AUTO",
                    EditUserSysNo = 0,
                    InDate = DateTime.Now,
                    InUserName = "AUTO",
                    InUserSysNo = 0
                });
            }
            conn.Execute(insertSql, supplierCategory_Resource);
        }



        #endregion

        #endregion

      
    }
}

