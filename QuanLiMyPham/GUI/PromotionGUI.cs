﻿using QuanLiMyPham.BUS;
using QuanLiMyPham.DAO;
using QuanLiMyPham.DTO;
using QuanLiMyPham.GUI.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QuanLiMyPham.GUI
{
    public partial class PromotionGUI : UserControl
    {
        public static string action;
        public PromotionGUI()
        {
            InitializeComponent();
            LoadDataGridView();
            SettingDataGridView();
            ShowRowAtIndex(0);
        }
        public void LoadDataGridView()
        {
            PromotionBUS bus = new PromotionBUS();
            bus.SetTableData();
            dataGridView.DataSource = PromotionBUS.promotionList;
        }

        public void SettingDataGridView()
        {
            dataGridView.Columns["MA"].Width = (int)(dataGridView.Width * 0.2);
            dataGridView.Columns["TEN"].Width = (int)(dataGridView.Width * 0.2);
            dataGridView.Columns["TIENKM"].Width = (int)(dataGridView.Width * 0.2);
            dataGridView.Columns["MUCTOITHIEU"].Width = (int)(dataGridView.Width * 0.2);
            dataGridView.Columns["MUCTOIDA"].Width = (int)(dataGridView.Width * 0.2);


            dataGridView.Columns["MA"].HeaderText = "ID";
            dataGridView.Columns["TEN"].HeaderText = "Name";
            dataGridView.Columns["TIENKM"].HeaderText = "Discount";
            dataGridView.Columns["MUCTOITHIEU"].HeaderText = "Minimum";
            dataGridView.Columns["MUCTOIDA"].HeaderText = "Maximum";
        }
        public void ShowRowAtIndex(int index)
        {
            idTxtBox.Text = dataGridView.Rows[index].Cells["MA"].Value.ToString();
            nameTxtBox.Text = dataGridView.Rows[index].Cells["TEN"].Value.ToString();
            discountTxtBox.Text = dataGridView.Rows[index].Cells["TIENKM"].Value.ToString();
            minTxtBox.Text = dataGridView.Rows[index].Cells["MUCTOITHIEU"].Value.ToString();
            maxTxtBox.Text = dataGridView.Rows[index].Cells["MUCTOIDA"].Value.ToString();
        }

        private void unselectBtn_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
            SettingDataGridView();

            searchTxtBox.Text = "";
            searchOpt.SelectedIndex = -1;

            addBtn.Enabled = true;
            dataGridView.CurrentCell = null;
            idTxtBox.Text = null;
            nameTxtBox.Text = null;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            action = "add";
            PromotionDialog dialog = new PromotionDialog();
            dialog.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            action = "edit";
            PromotionDialog dialog = new PromotionDialog();
            PromotionDTO promotionDTO = new PromotionDTO(idTxtBox.Text, nameTxtBox.Text, discountTxtBox.Text, minTxtBox.Text, maxTxtBox.Text);
            dialog.ShowData(promotionDTO);
            dialog.ShowDialog();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
