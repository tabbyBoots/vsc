using oop.demo;
using System.Diagnostics;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        // 同步準備起床(一步驟完才進行下一步驟)
        //demo01();
        // 非同步準備起床(特定步驟(1-4,7-8,9-10)可同時進行)
        //demo02();
        // 同步準備早餐(一步驟完才進行下一步驟)
        //demo03();
        // 非同步準備早餐(特定步驟(2-4)可同時進行)
        demo04();

        // Console.Write("按任意鍵結束 ...");
        Console.ReadKey();
    }

    /// <summary>
    /// 同步準備起床(一步驟完才進行下一步驟)
    /// 1.刷牙 (BrushTeeth) (耗時：2秒)
    /// 2.洗臉 (WashFace)  (耗時：3秒)
    /// 3.洗澡 (Bath) (耗時：4秒)
    /// 4.洗頭 (Shampoo)  (耗時：2秒)
    /// 5.吹乾頭髮 (BlowDryHair)  (耗時：1秒) 
    /// 6.穿衣服 (WearClothes)   (耗時：2秒) 
    /// 7.喝牛奶 (DrinkMilk)  (耗時：1秒)  
    /// 8.吃麵包 (EatBread)  (耗時：3秒)  
    /// 9.坐公車 (TakeBus)  (耗時：6秒)  
    /// 10.看書 (Reading)  (耗時：3秒) 
    /// </summary>
    private static void demo01()
    {
        // 引用起床類別
        using (GetUp getUp = new GetUp())
        {
            // 設定變數
            int int_step = 0;
            int int_count = 0;
            List<string> jobNames = new List<string>()
            {"刷牙","洗臉" , "洗澡" , "洗頭","吹乾頭髮","穿衣服","喝牛奶","吃麵包","坐公車","看書"};
            List<int> jobDelays = new List<int>()
            { 2 , 3 , 4 , 2 , 1 , 2 , 1 , 3 , 6 , 3 };

            // 開始計時
            Utilitys.stopwatch = Stopwatch.StartNew();

            // 顯示標題列
            Utilitys.ShowTitle("demo01.同步準備起床(一步驟完才進行下一步驟)", 61);
            Console.WriteLine("== ==== ==== ================================================");
            Console.WriteLine("序 耗時 累計 動作名稱");
            Console.WriteLine("== ==== ==== ================================================");
            int_count = 0;
            for (int i = 0; i < jobNames.Count; i++)
            {
                int_count += jobDelays[i];
                Console.Write("{0}   ", i.ToString().PadLeft(2, '0'));
                Console.Write("{0}   ", jobDelays[i].ToString().PadLeft(2, '0'));
                Console.Write("{0} ", int_count.ToString().PadLeft(2, '0'));
                Console.Write("{0}\r\n", jobNames[i]);
            }
            Console.WriteLine("== ==== ==== ================================================");
            Console.WriteLine();
            Console.WriteLine("執行結果如下：");
            Console.WriteLine("== ======== ============================== ======== ==== ====");
            Console.WriteLine("序 開始時間 動作名稱                       結束時間 耗時 累計");
            Console.WriteLine("== ======== ============================== ======== ==== ====");

            // 執行 10 個動作
            for (int i = 0; i < 10; i++)
            {
                int_step = i + 1;
                Utilitys.SetJobStepStart(int_step, jobNames[i], jobDelays[i], true);
                if (int_step == 1) getUp.BrushTeeth(jobDelays[i]);
                if (int_step == 2) getUp.WashFace(jobDelays[i]);
                if (int_step == 3) getUp.Bath(jobDelays[i]);
                if (int_step == 4) getUp.Shampoo(jobDelays[i]);
                if (int_step == 5) getUp.BlowDryHair(jobDelays[i]);
                if (int_step == 6) getUp.WearClothes(jobDelays[i]);
                if (int_step == 7) getUp.DrinkMilk(jobDelays[i]);
                if (int_step == 8) getUp.EatBread(jobDelays[i]);
                if (int_step == 9) getUp.TakeBus(jobDelays[i]);
                if (int_step == 10) getUp.Reading(jobDelays[i]);
                Utilitys.SetJobStepEnd();
            }

            // 等待輸入任意鍵結束.
            Console.WriteLine("== ============================== ======== ======== ==== ====");
            Utilitys.ShowEnding();
            Utilitys.stopwatch.Stop();
        }
    }

    /// <summary>
    /// 非同步準備起床(特定步驟(1-4,7-8,9-10)可同時進行)
    ///--1.刷牙 (BrushTeeth) (耗時：2秒)
    ///| 2.洗臉 (WashFace)  (耗時：3秒)
    ///| 3.洗澡 (Bath) (耗時：4秒)
    ///--4.洗頭 (Shampoo)  (耗時：2秒)
    ///  5.吹乾頭髮 (BlowDryHair)  (耗時：1秒) 
    ///  6.穿衣服 (WearClothes)   (耗時：2秒)
    ///--7.喝牛奶 (DrinkMilk)  (耗時：1秒)  
    ///|-8.吃麵包 (EatBread)  (耗時：3秒)  
    ///--9.坐公車 (TakeBus)  (耗時：6秒)  
    ///|-10.看書 (Reading)  (耗時：3秒) 
    /// </summary>
    private async static void demo02()
    {
        // 引用起床類別
        using (GetUp getUp = new GetUp())
        {
            // 引用起床模型
            using (JobModel jobModel = new JobModel())
            {
                // 設定變數
                List<Job> getupList = jobModel.GetGetUpJobList();

                // 顯示標題列
                Utilitys.ShowTitle("demo02.非同步準備起床(特定步驟(1-4,7-8,9-10)可同時進行)", 61);
                Console.WriteLine("== ==== ==== ================================================");
                Console.WriteLine("序 耗時 累計 動作名稱");
                Console.WriteLine("== ==== ==== ================================================");
                for (int i = 0; i < getupList.Count; i++)
                {
                    Console.Write("{0}   ", (i + 1).ToString().PadLeft(2, '0'));
                    Console.Write("{0}   ", getupList[i].JobDelay.ToString().PadLeft(2, '0'));
                    if (getupList[i].TotalsAsync == 0)
                        Console.Write("   ");
                    else
                        Console.Write("{0} ", getupList[i].TotalsAsync.ToString().PadLeft(2, '0'));
                    Console.Write("{0}\r\n", getupList[i].JobName);
                    if (i == 3 || i == 4 || i == 5 || i == 7 || i == 9)
                        Console.WriteLine("-- ---- ---- ------------------------------------------------");
                }

                Console.WriteLine("== ==== ==== ================================================");
                Console.WriteLine();
                Console.WriteLine("執行結果如下：");
                Console.WriteLine("== ======== ============================== ======== ==== ====");
                Console.WriteLine("序 開始時間 動作名稱                       結束時間 耗時 累計");
                Console.WriteLine("== ======== ============================== ======== ==== ====");

                // 開始計時
                Utilitys.stopwatch = Stopwatch.StartNew();

                // 步驟 1 - 4 非同步執行
                Utilitys.SetStartTime();

                // 設定步驟 1 - 4 非同步變數
                var brushTeethTask = getUp.BrushTeethTask(getupList[0].JobDelay); // 1.刷牙 (BrushTeeth) (耗時：2秒)
                var washFaceTask = getUp.WashFaceTask(getupList[1].JobDelay); // 2.洗臉 (WashFace)  (耗時：3秒)
                var bathTask = getUp.BathTask(getupList[2].JobDelay); // 3.洗澡 (Bath) (耗時：4秒)
                var shampooTask = getUp.ShampooTask(getupList[3].JobDelay); // 4.洗頭 (Shampoo)  (耗時：2秒)

                // 加入步驟 1 - 4 非同步變數到工作陣列中
                var Tasks1 = new List<Task> { brushTeethTask, washFaceTask, bathTask, shampooTask };
                while (Tasks1.Count > 0)
                {
                    // 取得已完成的工作
                    Task finishedTask = await Task.WhenAny(Tasks1);

                    // 執行已完成的工作
                    if (finishedTask == brushTeethTask) Utilitys.SetJobStepEnd(1, getupList[0].JobName, getupList[0].JobDelay);
                    if (finishedTask == washFaceTask) Utilitys.SetJobStepEnd(2, getupList[1].JobName, getupList[1].JobDelay);
                    if (finishedTask == bathTask) Utilitys.SetJobStepEnd(3, getupList[2].JobName, getupList[2].JobDelay);
                    if (finishedTask == shampooTask) Utilitys.SetJobStepEnd(4, getupList[3].JobName, getupList[3].JobDelay);

                    // 從工作陣列中移除已完成的工作
                    Tasks1.Remove(finishedTask);
                }

                // 步驟 5 吹乾頭髮 同步執行
                Utilitys.SetJobStepStart(5, getupList[4].JobName + " (同步)", getupList[4].JobDelay, true);
                getUp.BlowDryHair(getupList[4].JobDelay);
                Utilitys.SetJobStepEnd();

                // 步驟 6 穿衣服 同步執行
                Utilitys.SetJobStepStart(6, getupList[5].JobName + " (同步)", getupList[5].JobDelay, true);
                getUp.BlowDryHair(getupList[5].JobDelay);
                Utilitys.SetJobStepEnd();

                // 步驟 7 - 8 非同步執行
                Utilitys.SetStartTime();

                // 設定步驟 7 - 8 非同步變數
                var drinkMilkTask = Utilitys.DelayAsync(getupList[6].JobDelay); // 7.喝牛奶 (DrinkMilk)  (耗時：1秒) 
                var eatBreadTask = Utilitys.DelayAsync(getupList[7].JobDelay); // 8.吃麵包 (EatBread)  (耗時：3秒)  

                // 加入步驟 1 - 4 非同步變數到工作陣列中
                var Tasks2 = new List<Task> { drinkMilkTask, eatBreadTask };
                while (Tasks2.Count > 0)
                {
                    // 取得已完成的工作
                    Task finishedTask = await Task.WhenAny(Tasks2);

                    // 執行已完成的工作
                    if (finishedTask == drinkMilkTask) Utilitys.SetJobStepEnd(7, getupList[6].JobName, getupList[6].JobDelay);
                    if (finishedTask == eatBreadTask) Utilitys.SetJobStepEnd(8, getupList[7].JobName, getupList[7].JobDelay);

                    // 從工作陣列中移除已完成的工作
                    Tasks2.Remove(finishedTask);
                }

                // 步驟 9 - 10 非同步執行
                Utilitys.SetStartTime();

                // 設定步驟 9 - 10 非同步變數
                var takeBusTask = Utilitys.DelayAsync(getupList[8].JobDelay); // 9.坐公車 (TakeBus)  (耗時：6秒)  
                var readingTask = Utilitys.DelayAsync(getupList[9].JobDelay); // 10.看書 (Reading)  (耗時：3秒)  

                // 加入步驟 9 - 10 非同步變數到工作陣列中
                var Tasks3 = new List<Task> { takeBusTask, readingTask };
                while (Tasks3.Count > 0)
                {
                    // 取得已完成的工作
                    Task finishedTask = await Task.WhenAny(Tasks3);

                    // 執行已完成的工作
                    if (finishedTask == takeBusTask) Utilitys.SetJobStepEnd(9, getupList[8].JobName, getupList[8].JobDelay);
                    if (finishedTask == readingTask) Utilitys.SetJobStepEnd(10, getupList[9].JobName, getupList[9].JobDelay);

                    // 從工作陣列中移除已完成的工作
                    Tasks3.Remove(finishedTask);
                }

                // 等待輸入任意鍵結束.
                Console.WriteLine("== ==== ==== ================================================");
                Utilitys.ShowEnding();
                Utilitys.stopwatch.Stop();
            }
        }
    }

    /// <summary>
    /// 同步準備早餐
    /// 1.倒杯咖啡。（耗時：2秒）
    /// 2.熱鍋。（耗時：3秒）
    /// 3.煎兩顆蛋。（可同步執行耗時：每粒蛋需耗時3秒 = 6秒）
    /// 4.煎三片培根。（可同步執行耗時：切片需耗時2秒，煎培根需耗時 3 秒） 
    /// 5.烤兩片吐司。（可同步執行耗時：不管片數一律 4 秒）
    /// 6.在吐司塗上奶油和果醬
    /// 7.在吐司塗上奶油。（耗時：2秒）
    /// 8.在吐司塗上果醬。（耗時：2秒）
    /// 9.倒杯柳橙汁。（耗時：6秒）
    /// </summary>
    private static void demo03()
    {
        // 引用早餐類別
        using (BreakFast breakFast = new BreakFast())
        {
            using (JobModel jobModel = new JobModel())
            {
                // 設定變數
                int int_step = 0;
                int int_delay = 0;
                string str_job_name = "";
                List<Job> model = jobModel.GetBreakFastJobList();

                // 開始計時
                Utilitys.stopwatch = Stopwatch.StartNew();

                // 顯示標題列
                Utilitys.ShowTitle("demo03.同步準備早餐(一步驟完才進行下一步驟)", 61);
                Console.WriteLine("== ==== ==== ================================================");
                Console.WriteLine("序 耗時 累計 動作名稱");
                Console.WriteLine("== ==== ==== ================================================");

                int_step = 0;
                for (int i = 0; i < model.Count; i++)
                {
                    int_step = i + 1;
                    Console.Write("{0}   ", int_step.ToString().PadRight(2, ' '));
                    Console.Write("{0}   ", model[i].JobDelay.ToString().PadLeft(2, ' '));
                    Console.Write("{0} ", model[i].TotalsSync.ToString().PadLeft(2, ' '));
                    Console.Write("{0}\r\n", model[i].JobName);
                }
                Console.WriteLine("== ==== ==== ================================================");
                Console.WriteLine();
                Console.WriteLine("執行結果如下：");
                Console.WriteLine("== ======== ============================== ======== ==== ====");
                Console.WriteLine("序 開始時間 動作名稱                       結束時間 耗時 累計");
                Console.WriteLine("== ======== ============================== ======== ==== ====");

                // 執行所有步驟
                int_step = 0;
                for (int i = 0; i < model.Count; i++)
                {
                    int_step = i + 1; int_delay = model[i].JobDelay; str_job_name = model[i].JobName;
                    Utilitys.SetJobStepStart(int_step, str_job_name, int_delay, true);

                    if (int_step == 1) breakFast.PourCoffee(int_delay);     // 1.倒杯咖啡。（耗時：2秒）
                    if (int_step == 2) breakFast.HeatingPot(int_delay);     // 2.熱鍋（耗時：3秒）
                    if (int_step == 3) breakFast.FryEggs(2, int_delay);     // 3.煎兩顆蛋。（耗時：每粒蛋需耗時3秒 = 6秒）
                    if (int_step == 4) breakFast.FryBacon(2, 3);            // 4.煎三片培根。（耗時：切片需耗時2秒，煎培根需耗時 3 秒） 
                    if (int_step == 5) breakFast.ToastBread(int_delay);     // 5.烤兩片吐司。（耗時：不管片數一律 4 秒）
                    if (int_step == 7) breakFast.ApplyJam(int_delay);       // 7.塗果醬。（耗時：2 秒）
                    if (int_step == 8) breakFast.PourOrangeJuice(int_delay);// 8.塗奶油。（耗時：2 秒）
                    if (int_step == 9) breakFast.ApplyButter(int_delay);    // 9.倒杯柳橙汁。（耗時：6秒）

                    Utilitys.SetJobStepEnd();
                }

                // 結束所有作業
                Console.WriteLine("== ==== ==== ================================================");
                Utilitys.ShowEnding();
                Utilitys.stopwatch.Stop();
            }
        }
    }

    /// <summary>
    /// 非同步準備早餐(特定步驟(2-4)可同時進行)
    /// 1.倒杯咖啡。（耗時：2秒）
    /// 2.熱鍋。（耗時：3秒）
    /// 3.煎兩顆蛋。（可同步執行耗時：每粒蛋需耗時3秒 = 6秒）
    /// 4.煎三片培根。（可同步執行耗時：切片需耗時2秒，煎培根需耗時 3 秒） 
    /// 5.烤兩片吐司。（可同步執行耗時：不管片數一律 4 秒）
    /// 6.在吐司塗上奶油和果醬
    /// 7.在吐司塗上奶油。（耗時：2秒）
    /// 8.在吐司塗上果醬。（耗時：2秒）
    /// 9.倒杯柳橙汁。（耗時：6秒）
    /// </summary>
    private async static void demo04()
    {
        // 引用早餐類別
        using (BreakFast breakFast = new BreakFast())
        {
            using (JobModel jobModel = new JobModel())
            {
                // 設定變數
                int int_step = 0;
                int int_delay = 0;
                string str_job_name = "";
                Toast toast = new Toast(); //吐司物件
                List<Job> model = jobModel.GetBreakFastJobList();

                // 開始計時
                Utilitys.stopwatch = Stopwatch.StartNew();

                // 顯示標題列
                Utilitys.ShowTitle("demo04.非同步準備早餐(特定步驟(3-5 , 6-8)可同時進行)", 61);
                Console.WriteLine("== ==== ==== ================================================");
                Console.WriteLine("序 耗時 累計 動作名稱");
                Console.WriteLine("== ==== ==== ================================================");

                for (int i = 0; i < model.Count; i++)
                {
                    int_step = i + 1;
                    Console.Write("{0}   ", int_step.ToString().PadRight(2, ' '));
                    if (model[i].JobDelay == 0)
                        Console.Write("{0}   ", " ".PadLeft(2, ' '));
                    else
                        Console.Write("{0}   ", model[i].JobDelay.ToString().PadLeft(2, ' '));
                    if (model[i].TotalsAsync == 0)
                        Console.Write("{0} ", " ".PadLeft(2, ' '));
                    else
                        Console.Write("{0} ", model[i].TotalsAsync.ToString().PadLeft(2, ' '));
                    Console.Write("{0}", model[i].JobName);
                    if (int_step == 6) Console.Write(" -- 提示動作，不執行");
                    if (int_step == 7 || int_step == 8) Console.Write(" -- 同步執行");
                    Console.WriteLine();
                    if (int_step <= 2 || int_step >= 5)
                        Console.WriteLine("-- ---- ---- ------------------------------------------------");
                }
                Console.WriteLine("== ==== ==== ================================================");
                Console.WriteLine();
                Console.WriteLine("執行結果如下：");
                Console.WriteLine("== ======== ============================== ======== ==== ====");
                Console.WriteLine("序 開始時間 動作名稱                       結束時間 耗時 累計");
                Console.WriteLine("== ======== ============================== ======== ==== ====");

                // 步驟 1 - 2 (同步)
                int_step = 0;
                for (int i = 0; i < 2; i++)
                {
                    int_step = i + 1;
                    int_delay = model[i].JobDelay;
                    str_job_name = model[i].JobName;
                    Utilitys.SetJobStepStart(int_step, str_job_name, int_delay, true);

                    if (int_step == 1) breakFast.PourCoffee(int_delay);     // 1.倒杯咖啡。（耗時：2秒）
                    if (int_step == 2) breakFast.HeatingPot(int_delay);     // 2.熱鍋（耗時：3秒）

                    Utilitys.SetJobStepEnd();
                }

                // 步驟 3 - 5 (非同步)
                Utilitys.SetStartTime();

                // 設定步驟 3 - 5非同步變數
                var eggsTask = breakFast.FryEggsTask(model[int_step].JobDelay);     // 3.煎兩顆蛋。（耗時：每粒蛋需耗時3秒 = 6秒）
                var baconTask = breakFast.FryBaconTask(2, 3);                           // 4.煎三片培根。（耗時：切片需耗時2秒，煎培根需耗時 3 秒） 
                var toastTask = breakFast.ToastBreadTask(model[int_step + 2].JobDelay); // 5.烤兩片吐司。（耗時：不管片數一律 4 秒）

                // 加入步驟 3 - 5 非同步變數到工作陣列中
                var asyncTasks = new List<Task> { eggsTask, baconTask, toastTask };
                while (asyncTasks.Count > 0)
                {
                    // 取得已完成的工作
                    Task finishedTask = await Task.WhenAny(asyncTasks);

                    // 執行已完成的工作
                    if (finishedTask == eggsTask)
                    { Utilitys.SetJobStepStart(3, "煎兩顆蛋已完成", model[2].JobDelay, false); Utilitys.SetJobStepEnd(); }
                    if (finishedTask == baconTask)
                    { Utilitys.SetJobStepStart(4, "煎培根已完成", model[3].JobDelay, false); Utilitys.SetJobStepEnd(); }
                    if (finishedTask == toastTask)
                    { Utilitys.SetJobStepStart(5, "烤吐司已完成", model[4].JobDelay, false); Utilitys.SetJobStepEnd(); }

                    // 從工作陣列中移除已完成的工作
                    asyncTasks.Remove(finishedTask);
                }

                // 步驟 6 - 9 (同步)
                int_step = 0;
                for (int i = 5; i < 9; i++)
                {
                    int_step = i + 1;
                    str_job_name = model[i].JobName;
                    int_delay = model[i].JobDelay;
                    Utilitys.SetJobStepStart(int_step, str_job_name, int_delay, true);

                    if (int_step == 7) breakFast.ApplyButter(model[i].JobDelay);    // 7.塗上奶油（耗時：2秒）
                    if (int_step == 8) breakFast.ApplyJam(model[i].JobDelay);       // 8.塗上果醬（耗時：2秒）
                    if (int_step == 9) breakFast.PourOrangeJuice(model[i].JobDelay);// 9.倒杯柳橙汁（耗時：6秒）

                    Utilitys.SetJobStepEnd();
                }

                // 10.結束所有作業
                Console.WriteLine("== ==== ==== ================================================");
                Utilitys.ShowEnding();
                Utilitys.stopwatch.Stop();
            }
        }
    }
}
