using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cyrillic.Convert;

namespace Cyrillic.Convert.Test
{
    [TestClass]
    public class UKRTest
    {
        [TestMethod]
        public void TestAll()
        {
            string data = get_test_string_();

            var latin_list = get_sub_from_data_string_(data, 1);
            var ukr_list = get_sub_from_data_string_(data, 0);

            var conversion = new Conversion();

            var latin_result_data = conversion.UkrainianCyrillicToLatin(data);

            var latin_result = get_sub_from_data_string_(latin_result_data, 0);

            Assert.AreEqual(latin_result.Count, latin_result.Count);
            int cnt = latin_result.Count;

            for ( int i = 0; i < cnt; ++i)
            {
                var f = latin_list[i];
                var s = latin_result[i];

                Assert.AreEqual(f, s);
            }

            //It is impossible to convert the Latin variant to Ukrainian unambiguously
            //So -> convert latin to ukr and then ukr to latin and compare it
            var ukr_result_data = conversion.UkrainianLatinToCyrillic(latin_result_data);
            var ukr_result_data_to_latin = conversion.UkrainianCyrillicToLatin(ukr_result_data);
            var latin_from_ukr_result = get_sub_from_data_string_(ukr_result_data_to_latin, 0);

            Assert.AreEqual(latin_list.Count, latin_from_ukr_result.Count);

            cnt = latin_from_ukr_result.Count;

            for (int i = 0; i < cnt; ++i)
            {
                var f = latin_from_ukr_result[i];
                
                var s = latin_list[i];

                Assert.AreEqual(f, s);
            }


        }

        private List<string> get_sub_from_data_string_(string str, int offset)
        {
            var result = new List<string>(75);
            var seps = new char[] { ' ', '\t', '\n', '\r' };
            var strs = str.Split(seps, System.StringSplitOptions.RemoveEmptyEntries);

            int count = strs.Length;
            for ( int i = 0; i < count; i += 2)
            {
                result.Add(strs[i + offset]);
            }
            return result;
        }

        private string get_test_string_()
        {
            return @" ������      Alushta      
 �����      Andrii       
 ���������  Borshchahivka
 ���������   Borysenko    

 ³�����     Vinnytsia    
 ���������   Volodymyr    

 �����       Hadiach      
 ������      Bohdan       
 ���������   Zghurskyi    

 ������     Galagan      
 ������     Gorgany      

 �������     Donetsk      
 ������      Dmytro       

 г���       Rivne        
 ����        Oleh         
 ������      Esman        

 ���곺��    Yenakiieve   
 �����      Haievych     
 �����'�     Koropie      
                          
 �������     Zhytomyr     
 �����       Zhanna       
 ������     Zhezheliv    

 ����������  Zakarpattia  
 ����������  Kazymyrchuk  

 ������      Medvyn       
 ����������  Mykhailenko  

 ������     Ivankiv      
 ��������    Ivashchenko  

 ��������    Yizhakevych  
 �������    Kadyivka     
 ���'���     Marine       
                          

 ��������   Yosypivka    
 �����       Stryi        
 ������     Oleksii      
                          

 ���        Kyiv         
 ���������   Kovalenko    

 �������     Lebedyn      
 �����      Leonid       

 �������    Mykolaiv     
 �������     Marynych     

 ͳ���       Nizhyn       
 ������     Nataliia     

 �����       Odesa        
 ��������    Onyshchenko  

 �������     Poltava      
 �����       Petro        

 ���������� Reshetylivka 
 ����������� Rybchynskyi  

 ����        Sumy         
 ������     Solomiia     

 ��������   Ternopil     
 �����       Trots        

 �������     Uzhhorod     
 �����       Uliana       

 �����      Fastiv       
 Գ�����    Filipchuk    

 �����      Kharkiv      
 ��������    Khrystyna    

 ���� Bila ������ Tserkva 
 ��������    Stetsenko    

 �������    Chernivtsi   
 ��������    Shevchenko   

 ������      Shostka      
 ��������    Kyshenky     

 �������     Shcherbukhy  
 ����        Hoshcha      
 ���������   Harashchenko 

 ���        Yurii        
 ��������   Koriukivka   

 ������      Yahotyn      
 ��������    Yaroshenko   
 ���������   Kostiantyn   
 ����'����   Znamianka    
 �������    Feodosiia ";
        }

    }
   

    
}
