using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace EvaluateFunction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] Frq = new int[26];
        int[] Value = new int[26];
        List<String> GetVariables(String Fn)
        {
            
            for (int i = 0; i < 26; i++) Frq[i] = 0;
            foreach(char C in Fn.ToCharArray())
            {
                if(C>='A' && C<='Z')Frq[C - 'A']++;
            }
            List<String> Ans = new List<String>();

            for(int i=0;i<26;i++)
            {
                if(Frq[i] > 0)
                {
                    Ans.Add((char)(i + 'A') + "");
                }
            }

            return Ans;

        }
        int GetPrecedence(char C)
        {
            if (C == '(') return -1;
            else if (C == '!') return 3;
            else if (C == '.') return 2;
            else return 1;
        }
        String GetPostFix(String S)
        {
            String Ans = "";
            Stack St = new Stack();
            foreach(char C in S.ToCharArray())
            {
                if (C >= 'A' && C <= 'Z')
                {
                    Ans += C;
                }
                else
                {
                    if (C == '(') St.Push(C);
                    else if(C == ')')
                    {
                        
                        while (St.Count > 0 && ((char)St.Peek()) != '(') Ans += St.Pop();
                        
                        St.Pop();
                    }
                    else
                    {
                        if (St.Count == 0) St.Push(C);
                        else if (GetPrecedence(C)<= GetPrecedence((char)St.Peek()))
                        {
                            Ans += St.Pop();
                            St.Push(C);
                        }
                        else St.Push(C);
                    }
                }
            }
            while (St.Count > 0) Ans += St.Pop();

            return Ans;
        }
        char getValue(char C1 , char C2 , char Op)
        {
            int RealValue1, RealValue2;
            if (C1 >= 'A' && C1 <= 'Z') RealValue1 = Value[C1 - 'A'];
            else RealValue1 = C1 - '0';

            if (C2 >= 'A' && C2 <= 'Z') RealValue2 = Value[C2 - 'A'];
            else RealValue2 = C2 - '0';

            if(C1 == '!')
            {
                if (C2 >= 'A' && C2 <= 'Z') return Value[C2 - 'A'] > 0 ? '0' : '1';
                else return C2 == '1' ? '0' : '1';
            }
            if (C2 == '!')
            {
                if (C1 >= 'A' && C1 <= 'Z') return Value[C1 - 'A'] > 0 ? '0' : '1';
                else return C1 == '1' ? '0' : '1';
            }


            if (Op == '.')
            {
                
                if (RealValue1 == 1 && RealValue2 == 1) return '1';
                else return '0';
            }
            else
            {
                if (RealValue1 == 1 || RealValue2 == 1) return '1';
                return '0';
            }
        }
        String EvalutePostFix(String S)
        {
            Stack St = new Stack();
            foreach(char C in S.ToCharArray())
            {
                if (C >= 'A' && C <= 'Z') St.Push(C);
                else if(C == '!')
                {
                    char Op1 = (char)St.Pop();
                    St.Push(getValue(Op1, '!', 'X'));
                }
                else
                {
                    char Op1 = (char)St.Pop();
                    char Op2 = (char)St.Pop();
                    
                    St.Push(getValue(Op1 , Op2 , C));
                }
            }
            while(St.Count > 1)
            {
                char Op1 = (char)St.Pop();
                char Op2 = (char)St.Pop();
                St.Push(getValue(Op1, Op2, 'X'));
            }
            return St.Pop() + "";
        }
        String GetRealValue(String Function , String Combination)
        {
            String PostFix = GetPostFix(Function);
            //MessageBox.Show(PostFix);
            for (int i = 0; i < 26; i++) Value[i] = 0;
            int Cnt = 0;
            for (int i = 0; i < 26; i++)
            {
                if (Frq[i] > 0)
                {
                    Value[i] = Combination[Cnt++] - '0';
                }
            }
            String Evalute = EvalutePostFix(PostFix);
            
            return Evalute;
        }
        private void Evalute_Click(object sender, EventArgs e)
        {
            Pnl1.Controls.Clear();
            String Function = Fn.Text;
            List<String> Variables = GetVariables(Function);
            int Width = Pnl1.Width;
            int NumberOfVariables = Variables.Count;
            int WidthForEach = Width / (NumberOfVariables + 2);
            foreach (String X in Variables)
            {
                Label L = new Label() { Text = X };
                L.Width = WidthForEach;
                L.TextAlign = ContentAlignment.MiddleCenter;
                Pnl1.Controls.Add(L);
            }
            Pnl1.Controls.Add(new Label() { Text = Function , Width = WidthForEach , TextAlign = ContentAlignment.MiddleCenter});
            for(int i=0;i<(1<<NumberOfVariables);i++)
            {

                String Combination = "";
                for (int j= NumberOfVariables - 1; j>=0;j--)
                {
                    Label L = new Label();
                    L.Width = WidthForEach;
                    L.TextAlign = ContentAlignment.MiddleCenter;
                    String Content = "";
                    if ((i & (1 << j)) > 0) Content = "1";
                    else Content = "0";
                    L.Text = Content;
                    Combination += Content;
                    Pnl1.Controls.Add(L);
                }
                Label L2 = new Label() { Text = GetRealValue(Function , Combination)};
                L2.Width = WidthForEach;
                L2.TextAlign = ContentAlignment.MiddleCenter;
                Pnl1.Controls.Add(L2);
            }
        }
    }
}
