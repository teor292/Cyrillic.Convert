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
            return @" Алушта      Alushta      
 Андрій      Andrii       
 Борщагівка  Borshchahivka
 Борисенко   Borysenko    

 Вінниця     Vinnytsia    
 Володимир   Volodymyr    

 Гадяч       Hadiach      
 Богдан      Bohdan       
 Згурський   Zghurskyi    

 Ґалаґан     Galagan      
 Ґорґани     Gorgany      

 Донецьк     Donetsk      
 Дмитро      Dmytro       

 Рівне       Rivne        
 Олег        Oleh         
 Есмань      Esman        

 Єнакієве    Yenakiieve   
 Гаєвич      Haievych     
 Короп'є     Koropie      
                          
 Житомир     Zhytomyr     
 Жанна       Zhanna       
 Жежелів     Zhezheliv    

 Закарпаття  Zakarpattia  
 Казимирчук  Kazymyrchuk  

 Медвин      Medvyn       
 Михайленко  Mykhailenko  

 Іванків     Ivankiv      
 Іващенко    Ivashchenko  

 Їжакевич    Yizhakevych  
 Кадиївка    Kadyivka     
 Мар'їне     Marine       
                          

 Йосипівка   Yosypivka    
 Стрий       Stryi        
 Олексій     Oleksii      
                          

 Київ        Kyiv         
 Коваленко   Kovalenko    

 Лебедин     Lebedyn      
 Леонід      Leonid       

 Миколаїв    Mykolaiv     
 Маринич     Marynych     

 Ніжин       Nizhyn       
 Наталія     Nataliia     

 Одеса       Odesa        
 Онищенко    Onyshchenko  

 Полтава     Poltava      
 Петро       Petro        

 Решетилівка Reshetylivka 
 Рибчинський Rybchynskyi  

 Суми        Sumy         
 Соломія     Solomiia     

 Тернопіль   Ternopil     
 Троць       Trots        

 Ужгород     Uzhhorod     
 Уляна       Uliana       

 Фастів      Fastiv       
 Філіпчук    Filipchuk    

 Харків      Kharkiv      
 Христина    Khrystyna    

 Біла Bila Церква Tserkva 
 Стеценко    Stetsenko    

 Чернівці    Chernivtsi   
 Шевченко    Shevchenko   

 Шостка      Shostka      
 Кишеньки    Kyshenky     

 Щербухи     Shcherbukhy  
 Гоща        Hoshcha      
 Гаращенко   Harashchenko 

 Юрій        Yurii        
 Корюківка   Koriukivka   

 Яготин      Yahotyn      
 Ярошенко    Yaroshenko   
 Костянтин   Kostiantyn   
 Знам'янка   Znamianka    
 Феодосія    Feodosiia ";
        }

    }
   

    
}
