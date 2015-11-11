using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Character_Calculator
{
    public partial class form_main : Form
    {
        string program_version = "Program Version: 0.1.1.1";
        string game_version = "Game Version: 0.2.4.2";

        int level = 0;
        double stat_points = 15;
        int skill_points = 5;

        const int STR = 10; //BASE 10
        const int DEX = 10;
        const int MAG = 10;
        const int INT = 10;
        const int CON = 10;
        const int CHA = 10;

        int STR_mod = 0; //MODIFIED BY BUTTONS
        int DEX_mod = 0;
        int MAG_mod = 0;
        int INT_mod = 0;
        int CON_mod = 0;
        int CHA_mod = 0;

        double STR_final = 10; //FINAL VALUE IN DIALOGUE
        double DEX_final = 10;
        double MAG_final = 10;
        double INT_final = 10;
        double CON_final = 10;
        double CHA_final = 10;

        double STR_bonus = 0; //BONUS VALUE FROM CLASS
        double DEX_bonus = 0;
        double MAG_bonus = 0;
        double INT_bonus = 0;
        double CON_bonus = 0;
        double CHA_bonus = 0;

        double HP_mod = 0; //MODIFIED BY BUTTONS
        double FP_mod = 0;

        double HP_final = 0; //FINAL CALC VALUES IN DIALOGUE
        double FP_final = 0;
        double AP_final = 0;
        double DEF_final = 0;
        double RES_final = 0;
        double MOVE_final = 0;
        double SPRINT_final = 0;
        double DODGE_final = 0;

        double HP_bonus = 0; //BONUS VALUE FROM CLASS
        double FP_bonus = 0;
        double AP_bonus = 0;
        double DEF_bonus = 0;
        double RES_bonus = 0;
        double MOVE_bonus = 0;
        double DODGE_bonus = 0;
        double SPRINT_bonus = 0;

        double move_calc = 0;

        public form_main()
        {
            InitializeComponent();
            setup();
        }

        public int setup()
        {
            update_all();
            MessageBox.Show("Character Calculator for TITLE PENDING\n\n" + program_version + "\n" + game_version + "\n\nProgram Written by Mark Snyder\n\nMore information can be found at:\nwww.sites.google.com/site/wolfendeathx/bg");

            return 0;
        }

        public int update_all()
        {
            update_stats(); //VALUE CHANGING FUNCTIONS COME FIRST
            calc_stats();

            update_level(); //DISPLAY FUNCTIONS COME SECOND
            update_points();
            update_stats_mod();
            update_stats_bonus();
            update_stats_final();
            update_calc_stats_bonus();
            update_calc_stats();

            check_errors(); //UPDATES ERRORS

            return 0;
        }

        public int update_level()
        {
            label_level_value.Text = $"{level}";

            return 0;
        }

        public int update_points()
        {
            label_stat_points_value.Text = $"{stat_points}";
            label_skill_points_value.Text = $"{skill_points}";

            return 0;
        }

        public int update_stats_final()
        {
            label_str_final.Text = $"{STR_final}";
            label_dex_final.Text = $"{DEX_final}";
            label_mag_final.Text = $"{MAG_final}";
            label_int_final.Text = $"{INT_final}";
            label_con_final.Text = $"{CON_final}";
            label_cha_final.Text = $"{CHA_final}";

            return 0;
        }

        public int update_stats_mod()
        {
            label_str_mod.Text = $"{STR_mod}";
            label_dex_mod.Text = $"{DEX_mod}";
            label_mag_mod.Text = $"{MAG_mod}";
            label_int_mod.Text = $"{INT_mod}";
            label_con_mod.Text = $"{CON_mod}";
            label_cha_mod.Text = $"{CHA_mod}";

            return 0;
        }

        public int update_stats_bonus()
        {
            label_str_bonus.Text = $"{STR_bonus}";
            label_dex_bonus.Text = $"{DEX_bonus}";
            label_mag_bonus.Text = $"{MAG_bonus}";
            label_int_bonus.Text = $"{INT_bonus}";
            label_con_bonus.Text = $"{CON_bonus}";
            label_cha_bonus.Text = $"{CHA_bonus}";

            return 0;
        }

        public int update_stats()
        {
            STR_final = STR + STR_mod + STR_bonus;
            DEX_final = DEX + DEX_mod + DEX_bonus;
            MAG_final = MAG + MAG_mod + MAG_bonus;
            INT_final = INT + INT_mod + INT_bonus;
            CON_final = CON + CON_mod + CON_bonus;
            CHA_final = CHA + CHA_mod + CHA_bonus;

            return 0;
        }

        public int calc_stats()
        {
            HP_final = (HP_bonus + HP_mod +  (STR_final / 2) + CON_final * 1.5);
            FP_final = (FP_bonus + FP_mod +  ((MAG_final /2) + (CON_final *1.5)));
            AP_final = (AP_bonus + (DEX_final + CON_final)/6 + 4);

            DEF_final = (DEF_bonus + ((CON_final + STR_final) / 7));
            RES_final = (RES_bonus + ((CON_final + MAG_final) / 7));
            DODGE_final = (DODGE_bonus + (((DEX_final * 1.5) + (INT_final / 2))/2 - 2));

            move_calc = (MOVE_bonus + ((DEX_final * 1.5) + (CON / 2)) / 4);
            MOVE_final = (move_calc);
            SPRINT_final = (move_calc * 1.5);

            HP_final = Math.Floor(HP_final);
            FP_final = Math.Floor(FP_final);
            AP_final = Math.Floor(AP_final);

            DEF_final = Math.Floor(DEF_final);
            RES_final = Math.Floor(RES_final);
            DODGE_final = Math.Floor(DODGE_final);

            MOVE_final = Math.Floor(MOVE_final);
            SPRINT_final = Math.Floor(SPRINT_final);

            return 0;
        }

        public int update_calc_stats()
        {
            label_hp_mod.Text = $"{HP_mod}";
            label_fp_mod.Text = $"{FP_mod}";

            label_hp_final.Text = $"{HP_final}";
            label_fp_final.Text = $"{FP_final}";
            label_ap_final.Text = $"{AP_final}";

            label_def_final.Text = $"{DEF_final}";
            label_res_final.Text = $"{RES_final}";
            label_dodge_final.Text = $"{DODGE_final}";

            label_move_final.Text = $"{MOVE_final}";
            label_sprint_final.Text = $"{SPRINT_final}";

            return 0;
        }

        public int update_calc_stats_bonus()
        {
            label_hp_bonus.Text = $"{HP_bonus}";
            label_fp_bonus.Text = $"{FP_bonus}";
            label_ap_bonus.Text = $"{AP_bonus}";

            label_def_bonus.Text = $"{DEF_bonus}";
            label_res_bonus.Text = $"{RES_bonus}";
            label_dodge_bonus.Text = $"{DODGE_bonus}";

            label_move_bonus.Text = $"{MOVE_bonus}";
            label_sprint_bonus.Text = $"{SPRINT_bonus}";

            return 0;
        }

        public int decrementor(ref double final, ref int mod)
        {
            if (final > 8)
            {
                if (mod >= 0)
                    stat_points += (--mod / 2) + 1;
                else
                    stat_points += (--mod / 2) + (mod * -1);
            }

            update_all();
            return 0;
        }

        public int incrementor(ref int mod)
        {
            if (mod >= 0)
            {
                if (stat_points > (mod / 2))
                    stat_points -= (++mod + 1) / 2;
            }
            else
            {
                if ((stat_points) * -1 < (mod / 2))
                    stat_points -= (++mod - 2) / -2;
            }

            update_all();
            return 0;
        }

        public int check_errors()
        {
            textBox_error.Text = "Error List:";

            if(stat_points < 0)
            {
                label_stat_points_value.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nStat Points cannot be less than 0";
            }
            else
            {
                label_stat_points_value.ForeColor = System.Drawing.Color.Black;
            }

            if (STR_final < 8)
            {
                label_str_final.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nSTR cannot be less than 8";
            }
            else
            {
                label_str_final.ForeColor = System.Drawing.Color.Black;
            }

            if (DEX_final < 8)
            {
                label_dex_final.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nDEX cannot be less than 8";
            }
            else
            {
                label_dex_final.ForeColor = System.Drawing.Color.Black;
            }

            if (MAG_final < 8)
            {
                label_mag_final.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nMAG cannot be less than 8";
            }
            else
            {
                label_mag_final.ForeColor = System.Drawing.Color.Black;
            }

            if (INT_final < 8)
            {
                label_int_final.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nINT cannot be less than 8";
            }
            else
            {
                label_int_final.ForeColor = System.Drawing.Color.Black;
            }

            if (CON_final < 8)
            {
                label_con_final.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nCON cannot be less than 8";
            }
            else
            {
                label_con_final.ForeColor = System.Drawing.Color.Black;
            }

            if (CHA_final < 8)
            {
                label_cha_final.ForeColor = System.Drawing.Color.Red;
                textBox_error.Text += "\r\nCHA cannot be less than 8";
            }
            else
            {
                label_cha_final.ForeColor = System.Drawing.Color.Black;
            }

            return 0;
        }

        private void button_level_minus_Click(object sender, EventArgs e)
        {
            if(level > 0)
            {
                --level;
                stat_points -= 2;
                skill_points -= 1;
                update_all();
            }
        }

        private void button_level_plus_Click(object sender, EventArgs e)
        {
            if (level < 5)
            {
                ++level;
                stat_points += 2;
                skill_points += 1;
                update_all();
            }
        }

        private void button_str_minus_Click(object sender, EventArgs e)
        {
            decrementor(ref STR_final, ref STR_mod);
        }

        private void button_str_plus_Click(object sender, EventArgs e)
        {
            incrementor(ref STR_mod);
        }

        private void button_dex_minus_Click(object sender, EventArgs e)
        {
            decrementor(ref DEX_final, ref DEX_mod);
        }

        private void button_dex_plus_Click(object sender, EventArgs e)
        {
            incrementor(ref DEX_mod);
        }

        private void button_mag_minus_Click(object sender, EventArgs e)
        {
            decrementor(ref MAG_final, ref MAG_mod);
        }

        private void button_mag_plus_Click(object sender, EventArgs e)
        {
            incrementor(ref MAG_mod);
        }

        private void button_int_minus_Click(object sender, EventArgs e)
        {
            decrementor(ref INT_final, ref INT_mod);
        }

        private void button_int_plus_Click(object sender, EventArgs e)
        {
            incrementor(ref INT_mod);
        }

        private void button_con_minus_Click(object sender, EventArgs e)
        {
            decrementor(ref CON_final, ref CON_mod);
        }

        private void button_con_plus_Click(object sender, EventArgs e)
        {
            incrementor(ref CON_mod);
        }

        private void button_cha_minus_Click(object sender, EventArgs e)
        {
            decrementor(ref CHA_final, ref CHA_mod);
        }

        private void button_cha_plus_Click(object sender, EventArgs e)
        {
            incrementor(ref CHA_mod);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Character Calculator for TITLE PENDING\n\n" + program_version + "\n" + game_version + "\n\nProgram Written by Mark Snyder\n\nMore information can be found at:\nwww.sites.google.com/site/wolfendeathx/bg");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ADD SAVING DIALOGUE
            this.Close();
        }

        private void button_hp_minus_Click(object sender, EventArgs e)
        {
            if (HP_mod > 0)
            {
                --HP_mod;
                ++stat_points;
                update_all();
            }
        }

        private void button_hp_plus_Click(object sender, EventArgs e)
        {
            if (stat_points > 0)
            {
                ++HP_mod;
                --stat_points;
                update_all();
            }
        }

        private void button_fp_minus_Click(object sender, EventArgs e)
        {
            if (FP_mod > 0)
            {
                --FP_mod;
                ++stat_points;
                update_all();
            }
        }

        private void button_fp_plus_Click(object sender, EventArgs e)
        {
            if (stat_points > 0)
            {
                ++FP_mod;
                --stat_points;
                update_all();
            }
        }

        private void radio_hero_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 2;
            DEX_bonus = 2;
            MAG_bonus = 2;
            INT_bonus = 2;
            CON_bonus = 2;
            CHA_bonus = 2;

            HP_bonus = 5;
            FP_bonus = 5;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 2;

            MOVE_bonus = 1;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_archer_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 1;
            DEX_bonus = 3;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_barbarian_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 6;
            DEX_bonus = 2;
            MAG_bonus = -1;
            INT_bonus = -1;
            CON_bonus = -1;
            CHA_bonus = -1;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 1;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_cleric_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 1;
            DEX_bonus = -1;
            MAG_bonus = 2;
            INT_bonus = 0;
            CON_bonus = 2;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 1;
            RES_bonus = 1;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_darkknight_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 1;
            DEX_bonus = 0;
            MAG_bonus = 1;
            INT_bonus = 0;
            CON_bonus = 2;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 1;
            RES_bonus = 1;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_fighter_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 2;
            DEX_bonus = 2;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_knight_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 0;
            DEX_bonus = -1;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = 5;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_mage_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 0;
            DEX_bonus = 0;
            MAG_bonus = 2;
            INT_bonus = 2;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 0;
            RES_bonus = 2;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_paladin_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 2;
            DEX_bonus = -1;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = 3;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_ranger_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 2;
            DEX_bonus = 2;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_rogue_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = -1;
            DEX_bonus = 6;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = -1;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 1;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_scorcerer_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 0;
            DEX_bonus = 0;
            MAG_bonus = 3;
            INT_bonus = 1;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 0;
            RES_bonus = 2;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_spellsword_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 1;
            DEX_bonus = 1;
            MAG_bonus = 1;
            INT_bonus = 1;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 1;
            RES_bonus = 1;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_swordsman_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 1;
            DEX_bonus = 3;
            MAG_bonus = 0;
            INT_bonus = 0;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 2;
            RES_bonus = 0;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_warlock_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 0;
            DEX_bonus = 0;
            MAG_bonus = 4;
            INT_bonus = 0;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 0;
            RES_bonus = 2;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }

        private void radio_wizard_CheckedChanged(object sender, EventArgs e)
        {
            STR_bonus = 0;
            DEX_bonus = 0;
            MAG_bonus = 1;
            INT_bonus = 3;
            CON_bonus = 0;
            CHA_bonus = 0;

            HP_bonus = 0;
            FP_bonus = 0;
            AP_bonus = 0;

            DEF_bonus = 0;
            RES_bonus = 2;

            MOVE_bonus = 0;
            DODGE_bonus = 0;

            update_all();
        }
    }
}