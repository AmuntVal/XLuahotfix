using UnityEngine;
using XLua;

namespace XLuaTest
{ 
    [Hotfix]
    [LuaCallCSharp]
    public class HotfixMultiply
    {
        public int Multiply(int a, int b)
        {
            return a + b;
        }
    }

    public class NoHotfixMultiply
    {
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    public class HotfixTestByChuck : MonoBehaviour
    {

        LuaEnv luaenv = new LuaEnv();
        string hint = "Before Hotfix: 1 * 2 = ";
        HotfixMultiply multi = new HotfixMultiply();

        //use this for initialization
        void Start()
        {
            /*
            Debug.Log("This is the hotfix test made by Chao Liu.");
            Debug.Log("Student ID: 2020214421.");
            
            LuaEnv luaenv = new LuaEnv();
            HotfixMultiply multi = new HotfixMultiply();
            NoHotfixMultiply ordinaryMulti = new NoHotfixMultiply();

            int CALL_TIME = 100 * 1000 * 1000;
            var start = System.DateTime.Now;
            for (int i = 0; i < CALL_TIME; i++)
                multi.Multiply(2, 1);
            var d1 = (System.DateTime.Now - start).TotalMilliseconds;
            Debug.Log("Hotfix uses " + d1);

            start = System.DateTime.Now;
            for (int i = 0; i < CALL_TIME; i++)
                ordinaryMulti.Multiply(2, 1);
            var d2 = (System.DateTime.Now - start).TotalMilliseconds;
            Debug.Log("NoHotfix uses " + d2);

            Debug.Log("drop:" + (d1 - d2) / d1);

            Debug.Log("Before fix: 2 * 1 =" + multi.Multiply(2, 1));
            luaenv.DoString(@"
            xlua.hotfix(CS.XLuaTest.HotfixMultiply, 'Multiply', function(self, a, b)
                return a * b
            end)
        ");
            Debug.Log("After fix: 2 * 1 =" + multi.Multiply(2, 1));
            */
        }

        // Update is called once per frame
        void Update()
        {
            /*
            string beforeHint = @"Before hotfix: 2 * 1 = " + multi.Multiply(1, 2);
            string afterHint = @"After hotfix: 2 * 1 =" + multi.Multiply(1, 2);
            
            GUIStyle style = GUI.skin.textArea;
            style.normal.textColor = Color.red;
            style.fontSize = 16;
            */

            //return multi.Multiply(1, 2);
            //OnGUI();
           // Debug.Log("product:" + multi.Multiply(1, 2));
        }


        void OnGUI()
        {

            GUIStyle style = GUI.skin.textArea;
            style.normal.textColor = Color.red;
            style.fontSize = 16;


            string hint = "Through Hotfix: 1 * 2 = " + multi.Multiply(1, 2);

            if (GUI.Button(new Rect(10, 10, 300, 80), "Hotfix"))
            {
                luaenv.DoString(@"
                xlua.hotfix(CS.XLuaTest.HotfixMultiply, 'Multiply', function(self, a, b)
                    return a * b
            end)
            ");

                hint = @"After Hotfix: ";
                //GUI.TextArea(new Rect(10, 100, 500, 290), hint, style);
            }

            if(GUI.Button(new Rect(500, 10, 300, 80), "Return"))
            {
                luaenv.DoString(@"
                xlua.hotfix(CS.XLuaTest.HotfixMultiply, 'Multiply', function(self, a, b)
                    return a + b
            end)
            ");

                hint = @"Before Hotfix: " + multi.Multiply(1, 2);
                //GUI.TextArea(new Rect(10, 100, 500, 290), hint, style);
            }

            string instruct = @"Hit the 'Hotfix' button to make the function right;
Hit the 'Return' button to go back to the original state. ";

            GUI.TextArea(new Rect(10, 100, 500, 290), hint, style);
            GUI.TextArea(new Rect(10, 400, 500, 290), instruct, style);
        }
    }
}

