//using System;
//using System.IO;
//using System.Xml.Linq;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        string kaynakDizinYolu = @"E:\görüntüleme";   //  izlemeye alacağımız dosya
//        string hedefDizinYolu = @"E:\hedefDizin";   // görüntülenen dosyanın kaydedileceği yer
//        string hataDizinYolu = @"E:\hataDizin"; // Hata durumunda dosyaları kaydedeceğimiz dizin

//        FileSystemWatcher watcher = new FileSystemWatcher(kaynakDizinYolu)
//        {
//            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
//        };

//        watcher.Created += (sender, e) =>
//        {
//            if (e.ChangeType == WatcherChangeTypes.Created)
//            {
//                Console.WriteLine($"Yeni Dosya Oluşturuldu: {e.FullPath}");
//                if (!ProcessXmlFile(e.FullPath, hedefDizinYolu))
//                {
//                    // İşlem başarısızsa, dosyayı hata dizinine taşı
//                    MoveFileToErrorDirectory(e.FullPath, hataDizinYolu);
//                }
//            }
//        };

//        watcher.EnableRaisingEvents = true;

//        Console.WriteLine("Dosya izleme başlatıldı. Çıkış yapmak için Enter tuşuna basın.");
//        Console.ReadLine();

//        watcher.EnableRaisingEvents = false;
//    }

//    static bool ProcessXmlFile(string filePath, string hedefDizinYolu)
//    {
//        try
//        {
//            XDocument xdoc = XDocument.Load(filePath);

//            XElement idNameElement = xdoc.Descendants("IDName").FirstOrDefault();
//            XElement idValueElement = xdoc.Descendants("IDValue").FirstOrDefault();

//            string idName = idNameElement?.Value;
//            string idValue = idValueElement?.Value;

//            // IDValue kontrolü ve diğer işlemler
//            //if (!string.IsNullOrEmpty(idValue) && idValue.All(char.IsDigit) && idValue.Length <= 7)
//            if (!string.IsNullOrEmpty(idValue) && idValue.All(char.IsDigit) && idValue.Length <= 7)
//            {
//                Console.WriteLine("Doğru bir değer: " + idValue);
//            }

//            {
//                foreach (var line in xdoc.Descendants("Line"))
//                {
//                    string lineName = (string)line.Attribute("LineName");

//                    foreach (var concLineResult in line.Elements("LineResult").Where(lr => (string)lr.Attribute("Unit") == "%" && (string)lr.Element("ResultValue") != "0"))
//                    {
//                        string unit = (string)concLineResult.Attribute("Unit");
//                        string resultValue = (string)concLineResult.Element("ResultValue");

//                        Console.WriteLine($"IDName: {idName}");
//                        Console.WriteLine($"IDValue: {idValue}");
//                        Console.WriteLine($"LineName: {lineName}");
//                        Console.WriteLine($"Unit: {unit}");
//                        Console.WriteLine($"ResultValue: {resultValue}");
//                        Console.WriteLine();

//                        string kayitDosyaAdi = Path.GetFileNameWithoutExtension(filePath) + "_bilgiler.txt";
//                        string kayitDosyaYolu = Path.Combine(hedefDizinYolu, kayitDosyaAdi);

//                        using (StreamWriter writer = new StreamWriter(kayitDosyaYolu, true))
//                        {
//                            writer.WriteLine($"IDName: {idName}");
//                            writer.WriteLine($"IDValue: {idValue}");
//                            writer.WriteLine($"LineName: {lineName}");
//                            writer.WriteLine($"Unit: {unit}");
//                            writer.WriteLine($"ResultValue: {resultValue}");
//                            writer.WriteLine();
//                        }
//                    }
//                }

//                // İşlem başarılı
//                return true;
//            }

//            // IDValue değeri işlenmediği için işlem başarısız
//            return false;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"XML dosyasını işlerken hata oluştu: {ex.Message}");
//            // İşlem başarısız, hata durumunda dosyayı hata dizinine taşı
//            return false;
//        }
//    }

//    static void MoveFileToErrorDirectory(string filePath, string hataDizinYolu)
//    {
//        try
//        {
//            string hataDosyaAdi = Path.GetFileName(filePath);
//            string hataDosyaYolu = Path.Combine(hataDizinYolu, hataDosyaAdi);

//            // Dosyayı hata dizinine taşı
//            File.Move(filePath, hataDosyaYolu);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Dosyayı hata dizinine taşırken hata oluştu: {ex.Message}");
//        }
//    }
//}



//using System;
//using System.IO;
//using System.Xml.Linq;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        string kaynakDizinYolu = @"E:\görüntüleme";   //  izlemeye alacağımız dosya
//        string hedefDizinYolu = @"E:\hedefDizin";   // görüntülenen dosyanın kaydedileceği yer
//        string hataDizinYolu = @"E:\hataDizin"; // Hata durumunda dosyaları kaydedeceğimiz dizin

//        FileSystemWatcher watcher = new FileSystemWatcher(kaynakDizinYolu)
//        {
//            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
//        };

//        watcher.Created += (sender, e) =>
//        {
//            if (e.ChangeType == WatcherChangeTypes.Created)
//            {
//                Console.WriteLine($"Yeni Dosya Oluşturuldu: {e.FullPath}");
//                if (!ProcessXmlFile(e.FullPath, hedefDizinYolu, hataDizinYolu)) // Değişiklik burada
//                {
//                    // İşlem başarısızsa, dosyayı hata dizinine taşı
//                    MoveFileToErrorDirectory(e.FullPath, hataDizinYolu);
//                }
//            }
//        };

//        watcher.EnableRaisingEvents = true;

//        Console.WriteLine("Dosya izleme başlatıldı. Çıkış yapmak için Enter tuşuna basın.");
//        Console.ReadLine();

//        watcher.EnableRaisingEvents = false;
//    }

//    static bool ProcessXmlFile(string filePath, string hedefDizinYolu, string hataDizinYolu) // Değişiklik burada
//    {
//        try
//        {
//            XDocument xdoc = XDocument.Load(filePath);

//            XElement idNameElement = xdoc.Descendants("IDName").FirstOrDefault();
//            XElement idValueElement = xdoc.Descendants("IDValue").FirstOrDefault();

//            string idName = idNameElement?.Value;
//            string idValue = idValueElement?.Value;

//            if (!string.IsNullOrEmpty(idValue) && idValue.All(char.IsDigit) && idValue.Length <= 7)
//            {
//                Console.WriteLine("Doğru bir değer: " + idValue);
//            }
//            else
//            {
//                Console.WriteLine("Hata: IDValue yalnızca rakamlardan oluşmalı ve en fazla 7 karakter uzunluğunda olmalıdır.");
//                MoveFileToErrorDirectory(filePath, hataDizinYolu);
//                return false;
//            }

//            foreach (var line in xdoc.Descendants("Line"))
//            {
//                string lineName = (string)line.Attribute("LineName");

//                foreach (var concLineResult in line.Elements("LineResult").Where(lr => (string)lr.Attribute("Unit") == "%" && (string)lr.Element("ResultValue") != "0"))
//                {
//                    string unit = (string)concLineResult.Attribute("Unit");
//                    string resultValue = (string)concLineResult.Element("ResultValue");

//                    Console.WriteLine($"IDName: {idName}");
//                    Console.WriteLine($"IDValue: {idValue}");
//                    Console.WriteLine($"LineName: {lineName}");
//                    Console.WriteLine($"Unit: {unit}");
//                    Console.WriteLine($"ResultValue: {resultValue}");
//                    Console.WriteLine();

//                    string kayitDosyaAdi = Path.GetFileNameWithoutExtension(filePath) + "_bilgiler.txt";
//                    string kayitDosyaYolu = Path.Combine(hedefDizinYolu, kayitDosyaAdi);

//                    using (StreamWriter writer = new StreamWriter(kayitDosyaYolu, true))
//                    {
//                        writer.WriteLine($"IDName: {idName}");
//                        writer.WriteLine($"IDValue: {idValue}");
//                        writer.WriteLine($"LineName: {lineName}");
//                        writer.WriteLine($"Unit: {unit}");
//                        writer.WriteLine($"ResultValue: {resultValue}");
//                        writer.WriteLine();
//                    }
//                }
//            }

//            // İşlem başarılı
//            return true;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"XML dosyasını işlerken hata oluştu: {ex.Message}");
//            // İşlem başarısız, hata durumunda dosyayı hata dizinine taşı
//            MoveFileToErrorDirectory(filePath, hataDizinYolu);
//            return false;
//        }
//    }

//    static void MoveFileToErrorDirectory(string filePath, string hataDizinYolu)
//    {
//        try
//        {
//            string hataDosyaAdi = Path.GetFileName(filePath);
//            string hataDosyaYolu = Path.Combine(hataDizinYolu, hataDosyaAdi);

//            // Dosyayı hata dizinine taşı
//            File.Move(filePath, hataDosyaYolu);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Dosyayı hata dizinine taşırken hata oluştu: {ex.Message}");
//        }
//    }
//}




//using System;
//using System.IO;
//using System.Xml.Linq;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        string kaynakDizinYolu = @"E:\görüntüleme";   // izlemeye alacağımız dosya
//        string hedefDizinYolu = @"E:\hedefDizin";   // görüntülenen dosyanın kaydedileceği yer
//        string hataDizinYolu = @"E:\hataDizin"; // Hata durumunda dosyaları kaydedeceğimiz dizin

//        FileSystemWatcher watcher = new FileSystemWatcher(kaynakDizinYolu)
//        {
//            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
//        };

//        watcher.Created += (sender, e) =>
//        {
//            if (e.ChangeType == WatcherChangeTypes.Created)
//            {
//                Console.WriteLine($"Yeni Dosya Oluşturuldu: {e.FullPath}");
//                if (!ProcessXmlFile(e.FullPath, hedefDizinYolu, hataDizinYolu)) // Değişiklik burada
//                {
//                    // İşlem başarısızsa, dosyayı hata dizinine taşı
//                    MoveFileToErrorDirectory(e.FullPath, hataDizinYolu);
//                }
//            }
//        };

//        watcher.EnableRaisingEvents = true;

//        Console.WriteLine("Dosya izleme başlatıldı. Çıkış yapmak için Enter tuşuna basın.");
//        Console.ReadLine();

//        watcher.EnableRaisingEvents = false;
//    }

//    static bool ProcessXmlFile(string filePath, string hedefDizinYolu, string hataDizinYolu)
//    {
//        try
//        {
//            XDocument xdoc = XDocument.Load(filePath);

//            XElement idNameElement = xdoc.Descendants("IDName").FirstOrDefault();
//            XElement idValueElement = xdoc.Descendants("IDValue").FirstOrDefault();

//            string idName = idNameElement?.Value;
//            string idValue = idValueElement?.Value;

//            // İlk 7 karakter yalnızca rakamlardan oluşmalı
//            if (!string.IsNullOrEmpty(idValue) && idValue.Length >= 6 && idValue.Substring(0, 6).All(char.IsDigit))
//            {
//                Console.WriteLine("Doğru bir değer: " + idValue);
//            }
//            else
//            {
//                Console.WriteLine("Hata: IDValue'nun ilk 7 karakteri yalnızca rakamlardan oluşmalıdır.");
//                MoveFileToErrorDirectory(filePath, hataDizinYolu);
//                return false;
//            }

//            foreach (var line in xdoc.Descendants("Line"))
//            {
//                string lineName = (string)line.Attribute("LineName");

//                foreach (var concLineResult in line.Elements("LineResult").Where(lr => (string)lr.Attribute("Unit") == "%" && (string)lr.Element("ResultValue") != "0"))
//                {
//                    string unit = (string)concLineResult.Attribute("Unit");
//                    string resultValue = (string)concLineResult.Element("ResultValue");

//                    Console.WriteLine($"IDName: {idName}");
//                    Console.WriteLine($"IDValue: {idValue}");
//                    Console.WriteLine($"LineName: {lineName}");
//                    Console.WriteLine($"Unit: {unit}");
//                    Console.WriteLine($"ResultValue: {resultValue}");
//                    Console.WriteLine();

//                    string kayitDosyaAdi = Path.GetFileNameWithoutExtension(filePath) + "_bilgiler.txt";
//                    string kayitDosyaYolu = Path.Combine(hedefDizinYolu, kayitDosyaAdi);

//                    using (StreamWriter writer = new StreamWriter(kayitDosyaYolu, true))
//                    {
//                        writer.WriteLine($"IDName: {idName}");
//                        writer.WriteLine($"IDValue: {idValue}");
//                        writer.WriteLine($"LineName: {lineName}");
//                        writer.WriteLine($"Unit: {unit}");
//                        writer.WriteLine($"ResultValue: {resultValue}");
//                        writer.WriteLine();
//                    }
//                }
//            }

//            // İşlem başarılı
//            return true;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"XML dosyasını işlerken hata oluştu: {ex.Message}");
//            // İşlem başarısız, hata durumunda dosyayı hata dizinine taşı
//            MoveFileToErrorDirectory(filePath, hataDizinYolu);
//            return false;
//        }
//    }

//    static void MoveFileToErrorDirectory(string filePath, string hataDizinYolu)
//    {
//        try
//        {
//            string hataDosyaAdi = Path.GetFileName(filePath);
//            string hataDosyaYolu = Path.Combine(hataDizinYolu, hataDosyaAdi);

//            // Dosyayı hata dizinine taşı
//            File.Move(filePath, hataDosyaYolu);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Dosyayı hata dizinine taşırken hata oluştu: {ex.Message}");
//        }
//    }
//}



//using System;
//using System.IO;
//using System.Xml.Linq;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        string kaynakDizinYolu = @"E:\görüntüleme";   //  izlemeye alacağımız dosya
//        string hedefDizinYolu = @"E:\hedefDizin";   // görüntülenen dosyanın kaydedileceği yer
//        string hataDizinYolu = @"E:\hataDizin"; // Hata durumunda dosyaları kaydedeceğimiz dizin

//        FileSystemWatcher watcher = new FileSystemWatcher(kaynakDizinYolu)
//        {
//            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
//        };

//        watcher.Created += (sender, e) =>
//        {
//            if (e.ChangeType == WatcherChangeTypes.Created)
//            {
//                Console.WriteLine($"Yeni Dosya Oluşturuldu: {e.FullPath}");
//                if (!ProcessXmlFile(e.FullPath, hedefDizinYolu, hataDizinYolu)) // Değişiklik burada
//                {
//                    // İşlem başarısızsa, dosyayı hata dizinine taşı
//                    MoveFileToErrorDirectory(e.FullPath, hataDizinYolu);
//                }
//            }
//        };

//        watcher.EnableRaisingEvents = true;

//        Console.WriteLine("Dosya izleme başlatıldı. Çıkış yapmak için Enter tuşuna basın.");
//        Console.ReadLine();

//        watcher.EnableRaisingEvents = false;
//    }

//    static bool ProcessXmlFile(string filePath, string hedefDizinYolu, string hataDizinYolu)
//    {
//        try
//        {
//            XDocument xdoc = XDocument.Load(filePath);

//            XElement idNameElement = xdoc.Descendants("IDName").FirstOrDefault();
//            XElement idValueElement = xdoc.Descendants("IDValue").FirstOrDefault();

//            string idName = idNameElement?.Value;
//            string idValue = idValueElement?.Value;

//            // İlk 7 karakter yalnızca rakamlardan oluşmalı
//            if (!string.IsNullOrEmpty(idValue) && idValue.Length >= 7 && idValue.Substring(0, 7).All(char.IsDigit))
//            {
//                Console.WriteLine("Doğru bir değer: " + idValue);
//            }
//            else
//            {
//                Console.WriteLine("Hata: IDValue'nun ilk 7 karakteri yalnızca rakamlardan oluşmalıdır.");
//                MoveFileToErrorDirectory(filePath, hataDizinYolu);
//                return false;
//            }

//            foreach (var line in xdoc.Descendants("Line"))
//            {
//                string lineName = (string)line.Attribute("LineName");

//                foreach (var concLineResult in line.Elements("LineResult").Where(lr => (string)lr.Attribute("Unit") == "%" && (string)lr.Element("ResultValue") != "0"))
//                {
//                    string unit = (string)concLineResult.Attribute("Unit");
//                    string resultValue = (string)concLineResult.Element("ResultValue");

//                    Console.WriteLine($"IDName: {idName}");
//                    Console.WriteLine($"IDValue: {idValue}");
//                    Console.WriteLine($"LineName: {lineName}");
//                    Console.WriteLine($"Unit: {unit}");
//                    Console.WriteLine($"ResultValue: {resultValue}");
//                    Console.WriteLine();

//                    string kayitDosyaAdi = Path.GetFileNameWithoutExtension(filePath) + "_bilgiler.txt";
//                    string kayitDosyaYolu = Path.Combine(hedefDizinYolu, kayitDosyaAdi);

//                    using (StreamWriter writer = new StreamWriter(kayitDosyaYolu, true))
//                    {
//                        writer.WriteLine($"IDName: {idName}");
//                        writer.WriteLine($"IDValue: {idValue}");
//                        writer.WriteLine($"LineName: {lineName}");
//                        writer.WriteLine($"Unit: {unit}");
//                        writer.WriteLine($"ResultValue: {resultValue}");
//                        writer.WriteLine();
//                    }
//                }
//            }

//            // İşlem başarılı
//            return true;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"XML dosyasını işlerken hata oluştu: {ex.Message}");
//            // İşlem başarısız, hata durumunda dosyayı hata dizinine taşı
//            MoveFileToErrorDirectory(filePath, hataDizinYolu);
//            return false;
//        }
//    }

//    static void MoveFileToErrorDirectory(string filePath, string hataDizinYolu)
//    {
//        try
//        {
//            string hataDosyaAdi = Path.GetFileName(filePath);
//            string hataDosyaYolu = Path.Combine(hataDizinYolu, hataDosyaAdi);

//            // Dosyayı hata dizinine taşı
//            File.Move(filePath, hataDosyaYolu);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Dosyayı hata dizinine taşırken hata oluştu: {ex.Message}");
//        }
//    }
//}



//using System;
//using System.IO;
//using System.Xml.Linq;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        string kaynakDizinYolu = @"E:\görüntüleme";
//        string hedefDizinYolu = @"E:\hedefDizin";
//        string hataDizinYolu = @"E:\hataDizin";

//        FileSystemWatcher watcher = new FileSystemWatcher(kaynakDizinYolu)
//        {
//            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
//        };

//        watcher.Created += (sender, e) =>
//        {
//            if (e.ChangeType == WatcherChangeTypes.Created)
//            {
//                Console.WriteLine($"Yeni Dosya Oluşturuldu: {e.FullPath}");
//                if (ProcessXmlFile(e.FullPath, hedefDizinYolu, hataDizinYolu))
//                {
//                    // Dosya başarıyla işlendiyse, dosyayı silebilirsiniz.
//                    File.Delete(e.FullPath);
//                    Console.WriteLine($"Dosya silindi: {e.FullPath}");
//                }
//                else
//                {
//                    MoveFileToErrorDirectory(e.FullPath, hataDizinYolu);
//                }
//            }
//        };

//        watcher.EnableRaisingEvents = true;

//        Console.WriteLine("Dosya izleme başlatıldı. Çıkış yapmak için Enter tuşuna basın.");
//        Console.ReadLine();

//        watcher.EnableRaisingEvents = false;
//    }

//    static bool ProcessXmlFile(string filePath, string hedefDizinYolu, string hataDizinYolu)
//    {
//        try
//        {
//            XDocument xdoc = XDocument.Load(filePath);

//            XElement idNameElement = xdoc.Descendants("IDName").FirstOrDefault();
//            XElement idValueElement = xdoc.Descendants("IDValue").FirstOrDefault();

//            string idName = idNameElement?.Value;
//            string idValue = idValueElement?.Value;

//            if (!string.IsNullOrEmpty(idValue) && idValue.Length >= 7 && idValue.Substring(0, 7).All(char.IsDigit))
//            {
//                Console.WriteLine("Doğru bir değer: " + idValue);
//            }
//            else
//            {
//                Console.WriteLine("Hata: IDValue'nun ilk 7 karakteri yalnızca rakamlardan oluşmalıdır.");
//                MoveFileToErrorDirectory(filePath, hataDizinYolu);
//                return false;
//            }

//            foreach (var line in xdoc.Descendants("Line"))
//            {
//                string lineName = (string)line.Attribute("LineName");

//                foreach (var concLineResult in line.Elements("LineResult").Where(lr => (string)lr.Attribute("Unit") == "%" && (string)lr.Element("ResultValue") != "0"))
//                {
//                    string unit = (string)concLineResult.Attribute("Unit");
//                    string resultValue = (string)concLineResult.Element("ResultValue");

//                    Console.WriteLine($"IDName: {idName}");
//                    Console.WriteLine($"IDValue: {idValue}");
//                    Console.WriteLine($"LineName: {lineName}");
//                    Console.WriteLine($"Unit: {unit}");
//                    Console.WriteLine($"ResultValue: {resultValue}");
//                    Console.WriteLine();

//                    string kayitDosyaAdi = Path.GetFileNameWithoutExtension(filePath) + "_bilgiler.txt";
//                    string kayitDosyaYolu = Path.Combine(hedefDizinYolu, kayitDosyaAdi);

//                    using (StreamWriter writer = new StreamWriter(kayitDosyaYolu, true))
//                    {
//                        writer.WriteLine($"IDName: {idName}");
//                        writer.WriteLine($"IDValue: {idValue}");
//                        writer.WriteLine($"LineName: {lineName}");
//                        writer.WriteLine($"Unit: {unit}");
//                        writer.WriteLine($"ResultValue: {resultValue}");
//                        writer.WriteLine();
//                    }
//                }
//            }

//            return true;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"XML dosyasını işlerken hata oluştu: {ex.Message}");
//            MoveFileToErrorDirectory(filePath, hataDizinYolu);
//            return false;
//        }
//    }

//    static void MoveFileToErrorDirectory(string filePath, string hataDizinYolu)
//    {
//        try
//        {
//            string hataDosyaAdi = Path.GetFileName(filePath);
//            string hataDosyaYolu = Path.Combine(hataDizinYolu, hataDosyaAdi);

//            File.Move(filePath, hataDosyaYolu);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Dosyayı hata dizinine taşırken hata oluştu: {ex.Message}");
//        }
//    }
//}


using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;

class Program
{
    static void Main()
    {
        string kaynakDizinYolu = @"E:\görüntüleme";
        string hedefDizinYolu = @"E:\hedefDizin";
        string hataDizinYolu = @"E:\hataDizin";

        FileSystemWatcher watcher = new FileSystemWatcher(kaynakDizinYolu)
        {
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
        };

        watcher.Created += (sender, e) =>
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                Console.WriteLine($"Yeni Dosya Oluşturuldu: {e.FullPath}");
                if (ProcessXmlFile(e.FullPath, hedefDizinYolu, hataDizinYolu))
                {
                    // Dosya başarıyla işlendiyse, dosyayı silebilirsiniz.
                    File.Delete(e.FullPath);
                    Console.WriteLine($"Dosya silindi: {e.FullPath}");
                }
                else
                {
                    MoveFileToErrorDirectory(e.FullPath, hataDizinYolu);
                }
            }
        };

        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Dosya izleme başlatıldı. Çıkış yapmak için Enter tuşuna basın.");
        Console.ReadLine();

        watcher.EnableRaisingEvents = false;
    }

    static bool ProcessXmlFile(string filePath, string hedefDizinYolu, string hataDizinYolu)
    {
        try
        {
            XDocument xdoc = XDocument.Load(filePath);

            XElement idNameElement = xdoc.Descendants("IDName").FirstOrDefault();
            XElement idValueElement = xdoc.Descendants("IDValue").FirstOrDefault();

            string idName = idNameElement?.Value;
            string idValue = idValueElement?.Value;

            if (!string.IsNullOrEmpty(idValue) && idValue.Length >= 7 && idValue.Substring(0, 7).All(char.IsDigit))
            {
                Console.WriteLine("Doğru bir değer: " + idValue);
            }
            else
            {
                Console.WriteLine("Hata: IDValue'nun ilk 7 karakteri yalnızca rakamlardan oluşmalıdır.");
                MoveFileToErrorDirectory(filePath, hataDizinYolu);
                return false;
            }

            Console.WriteLine($"IDName: {idName}");
            Console.WriteLine($"IDValue: {idValue}");

            foreach (var line in xdoc.Descendants("Line"))
            {
                string lineName = (string)line.Attribute("LineName");

                foreach (var concLineResult in line.Elements("LineResult").Where(lr => (string)lr.Attribute("Unit") == "%" && (string)lr.Element("ResultValue") != "0"))
                {
                    string unit = (string)concLineResult.Attribute("Unit");
                    string resultValue = (string)concLineResult.Element("ResultValue");

                    Console.WriteLine($"LineName: {lineName}");
                    Console.WriteLine($"Unit: {unit}");
                    Console.WriteLine($"ResultValue: {resultValue}");
                    Console.WriteLine();
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"XML dosyasını işlerken hata oluştu: {ex.Message}");
            MoveFileToErrorDirectory(filePath, hataDizinYolu);
            return false;
        }
    }

    static void MoveFileToErrorDirectory(string filePath, string hataDizinYolu)
    {
        try
        {
            string hataDosyaAdi = Path.GetFileName(filePath);
            string hataDosyaYolu = Path.Combine(hataDizinYolu, hataDosyaAdi);

            File.Move(filePath, hataDosyaYolu);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dosyayı hata dizinine taşırken hata oluştu: {ex.Message}");
        }
    }
}



