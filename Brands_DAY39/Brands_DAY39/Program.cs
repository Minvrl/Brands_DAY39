using Brands_DAY39;
using System.Data.SqlClient;
using System.Transactions;

BrandService bs = new BrandService();   

string opt;

do
{
    Console.WriteLine("\n 1. Create brand ");
    Console.WriteLine("2. Delete brand");
    Console.WriteLine("3. Get brand by ID");
    Console.WriteLine("4. Get all brands");
    Console.WriteLine("5. Update brand");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Enter operation: ");
    opt = Console.ReadLine();

    string idStr, yearStr,brandName;
    int id,year;
    
    switch (opt)
    {
        case "1":
            do
            {
                Console.Write("\n Enter brand name - ");
                brandName = Console.ReadLine();
            } while (string.IsNullOrEmpty(brandName));
            do
            {
                Console.Write("  Year - ");
                yearStr = Console.ReadLine();
            } while (!int.TryParse(yearStr,out year) || year<999 || year>10000);

           
             bs.CreateBrand(brandName, year);
             Console.WriteLine("\t Brand added !");
            break;
        case "2":
            do
            {
                Console.Write("\n Enter brand id - ");
                idStr = Console.ReadLine() ;
            } while (!int.TryParse(idStr,out id) || id<0);
            bs.DeleteBrand(id);
            Console.WriteLine("\t Brand deleted !");

            break;
        case "3":
            do
            {
                Console.Write("\n Enter brand id - ");
                idStr = Console.ReadLine();
            } while (!int.TryParse(idStr, out id) || id < 0);

            var data  = bs.GetBrandById(id);

            if(data == null) Console.WriteLine("Not found");
            else Console.WriteLine(data);

            break;
        case "4":
            Console.WriteLine("\n All Brands \n===============");
            foreach (var item in bs.GetAllBrands())
            {
                Console.WriteLine(item);
            }
            break;
        case "5":
            do
            {
                Console.Write("\n Enter brand id - ");
                idStr = Console.ReadLine();
            } while (!int.TryParse(idStr, out id) || id < 0);

            string updt;

            Console.Write("\n\tChoose for updating NAME or YEAR - ");
            updt = Console.ReadLine();

            switch (updt)
            {
                case "NAME":
                    do
                    {
                        Console.Write("Enter new brand name - ");
                        brandName = Console.ReadLine();
                    } while (string.IsNullOrEmpty(brandName));
                    bs.UpdateBrandName(id, brandName);
                    Console.WriteLine("Brand updated!");
                    break;
                case "YEAR":
                    do
                    {
                        Console.Write("Enter new Brand year - ");
                        yearStr = Console.ReadLine();
                    } while (!int.TryParse(yearStr, out year) || year < 999 || year > 10000);
                    bs.UpdateBrandYear(id, year);
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }

            break;
        case "0":
            Console.WriteLine("Goodbye !");
            break;
        default:
            Console.WriteLine("Wrong operator !");
            break;
    }

} while (opt !="0");
