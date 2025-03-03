internal class Program
{    private static void Main(string[] args)
    {
        // int a = 100;
        // int b = 300;
        // int rlt = findMax(a, b);
        // Console.Write("Result: {0} ...",rlt);

        //調用factorial 方法
        // Console.WriteLine("6 的階乘是： {0}", factorial(6));
        // Console.WriteLine("7 的階乘是： {0}", factorial(7));
        // Console.WriteLine("8 的階乘是： {0}", factorial(8));

        //區域變數宣告
        // int a = 100;
        // int b = 200;

        // Console.WriteLine("在交換之前，a 的值： {0}", a);
        // Console.WriteLine("在交換之前，b 的值： {0}", b);
        // Console.WriteLine("---------------------------");

        //呼叫函數来交换值 //傳值呼叫
        //swap(a, b);

        //呼叫函數来交换值 //傳址呼叫
        // swap(ref a, ref b);

        // Console.WriteLine("在交換之後，a 的值： {0}", a);
        // Console.WriteLine("在交換之後，b 的值： {0}", b);
        // Console.WriteLine("---------------------------");

        //demo01();
        //demo02();
        demo03();

        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();
    }  

    static int findMax(int x, int y){
        //區域變數宣告
        int result;

        if( x > y){
            result = x;
        }else{
            result = y;
        }
        return result;
    }   

    static int factorial(int n){
        int result;
        if(n == 1){
            return 1;
        }else{
            result = n*factorial(n-1);
            return result;
        }
    }

    //static void swap(int x, int y){   //傳值呼叫
    static void swap(ref int x, ref int y){     //傳址呼叫
        int temp = x;
        x = y;
        y = temp;
        Console.WriteLine("在交換之中，x 的值： {0}", x);
        Console.WriteLine("在交換之中，y 的值： {0}", y);
        Console.WriteLine("---------------------------");
    }

    static void demo01()
    {
        // 顯示標題列
        string str_title = "螢幕顯示出 Hello World!!";
        Console.WriteLine(new String('-', 50));
        Console.WriteLine("題目：{0}", str_title);
        Console.WriteLine(new String('-', 50));
        Console.WriteLine();

        // 在螢幕顯示出 Hello World!!
        Console.WriteLine("Hello World!");

        // 顯示結束列
        Console.WriteLine();
        Console.WriteLine(new String('-', 50));
    }

    static void demo02()
    {
        // 顯示標題列
        string str_title = "輸入姓名,並顯示在畫面上";
        Console.WriteLine(new String('-', 50));
        Console.WriteLine("題目：{0}", str_title);
        Console.WriteLine(new String('-', 50));
        Console.WriteLine();

        // 輸入姓名,並顯示在畫面上
        Console.Write("請輸入你的姓名：");
        string str_name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("你的姓名為：{0}", str_name);

        // 顯示結束列
        Console.WriteLine();
        Console.WriteLine(new String('-', 50));
    }

    static void demo03()
    {
        // 顯示標題列
        string str_title = "輸入兩數字進行加減乘除";
        Console.WriteLine(new String('-', 50));
        Console.WriteLine("題目：{0}", str_title);
        Console.WriteLine(new String('-', 50));
        Console.WriteLine();

        try
        {
            // 變數宣告
            int int_num1 = 0;
            int int_num2 = 0;
            string str_num1 = "";
            string str_num2 = "";
            bool bln_valid = true;

            // 輸入第一個數字值
            Console.Write("請輸入第一個數字,並按下 Enter 鍵：");
            str_num1 = Console.ReadLine();
            if (string.IsNullOrEmpty(str_num1))
            {
                Console.WriteLine("第一個數字不可為空白!!");
                bln_valid = false;
            }
            else if (!int.TryParse(str_num1, out int_num1))
            {
                Console.WriteLine("第一個數字必須為數字!!");
                bln_valid = false;
            }
            if (bln_valid)
            {
                // 輸入第二個數字值
                Console.Write("請輸入第二個數字,並按下 Enter 鍵：");
                str_num2 = Console.ReadLine();
                if (string.IsNullOrEmpty(str_num2))
                {
                    Console.WriteLine("第二個數字不可為空白!!");
                    bln_valid = false;
                }
                else if (!int.TryParse(str_num2, out int_num2))
                {
                    Console.WriteLine("第二個數字必須為數字!!");
                    bln_valid = false;
                }
            }

            if (bln_valid)
            {
                // 選擇運算方式
                Console.WriteLine();
                Console.WriteLine("請從下方選項選擇數字的運算方式(A - D):");
                Console.WriteLine("\tA. 加法 (Add)");
                Console.WriteLine("\tB. 減法 (Subtract)");
                Console.WriteLine("\tC. 乘法 (Multiply)");
                Console.WriteLine("\tD. 除法 (Divide)");
                Console.Write("請輸入您的選項( A - D)? ");
                string str_option = Console.ReadLine().ToUpper();
                Console.WriteLine();

                // 判斷輸人的選項來進行運算
                switch (str_option)
                {
                    case "A":
                        Console.WriteLine("運算結果: " + int_num1 + " + " + int_num2 + " = " + (int_num1 + int_num2));
                        break;
                    case "B":
                        Console.WriteLine("運算結果: {0} - {1} = {2}", int_num1, int_num2, (int_num1 - int_num2));
                        break;
                    case "C":
                        Console.WriteLine($"運算結果: {int_num1} * {int_num2} = " + (int_num1 * int_num2));
                        break;
                    case "D":
                        Console.WriteLine($"運算結果: {int_num1} / {int_num2} = {(int_num1 / int_num2)}");
                        break;
                }
            }
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine();
            Console.WriteLine("程式發生了應用程式上的錯誤!! 錯誤訊息如下:");
            Console.WriteLine(ex.Message);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine();
            Console.WriteLine("程式發生了除法上的錯誤!! 錯誤訊息如下:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("程式發生了不可預期的錯誤!! 錯誤訊息如下:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // 顯示結束列
            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
        }
    }
}