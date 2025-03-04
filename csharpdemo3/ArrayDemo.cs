public static class ArrayDemo{

    public static void demo02(string titleName)
    {
        // 顯示標題列
        Utilitys.ShowTitle(titleName);

        // 變數宣告
        string[,] arrayMember = new string[3,2]
        {
            {"Normal", "lv1user"},
            {"Vip", "lv2user"},
            {"Noble","lv3user"}
        };

        int[,] array2D1 = new int[,]
        {
            {1, 38},
            {2, 62},
            {3, 36},
            {4, 45}
        };

        int total = 0;
        int index = 0;

        // 顯示會員資料
        Console.WriteLine("顯示陣列 arrayMember 所有元素值：");
        index = 1;
        foreach(var item in arrayMember){
            Console.Write($"{item} ");            
            if(index % 2 == 0){
                Console.Write(" ");
                Console.WriteLine();
            }
            else{
                Console.Write(" = ");

            }
            index++;
        }
        Console.WriteLine("有：{0} 筆記錄!!", arrayMember.Length);
        Console.WriteLine();

        for(int i = 0; i < array2D1.Length; i += array2D1.Rank){
            if(i>0) Console.Write(" + ");
            Console.Write("{array2D1[index,1]}");
            total += array2D1[index,1];
            index++;
        }
        Console.WriteLine("  合計為：{0} ", total);
        Console.WriteLine();

    }










    public static void demo01(string titleName)
    {
        // 顯示標題列
        Utilitys.ShowTitle(titleName);

        int[] numberArray1;
        int[] numberArray2 = new int[5];
        int[] intArray1 = new int[] { 2, 3, 4, 5, 6 };
        int[] intArray2 = { 9, 8, 7, 6, 5 };
        string[] weekDays = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        string[] userName = { "John", "Mary", "Tom", "Jerry", "Andy" };

        numberArray1 = new int[] { 5, 6, 7, 8, 9 };
        numberArray2[0] = 6;
        numberArray2[1] = 7;
        numberArray2[2] = 8;
        numberArray2[3] = 9;
        numberArray2[4] = 10;


        // 顯示在畫面中
        Console.Write("陣列 numberArray1:\t\t");
        foreach (var item in numberArray1)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\r\n");

        Console.Write("陣列 numberArray2:\t\t");
        foreach (var item in numberArray2)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\r\n");

        Console.Write("陣列 intArray1:\t\t\t");
        foreach (var item in intArray1)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\r\n");

        Console.Write("陣列 intArray2:\t\t\t");
        foreach (var item in intArray2)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\r\n");

        Console.Write("陣列 weekDays:\t\t\t");
        foreach (var item in weekDays)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\r\n");

        Console.Write("陣列 userName:\t\t\t");
        foreach (var item in userName)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\r\n");
    }
}