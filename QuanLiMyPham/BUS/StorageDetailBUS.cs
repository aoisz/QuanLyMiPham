﻿using QuanLiMyPham.DAO;
using QuanLiMyPham.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLiMyPham.BUS
{
    internal class StorageDetailBUS
    {
        public static DataTable storageDetailList;

        public StorageDetailBUS() { }

        public void SetTableData()
        {
            StorageDetailDAO storageDetailDAO = new StorageDetailDAO();
            if (storageDetailList == null)
            {
                storageDetailList = new DataTable();
                storageDetailList = storageDetailDAO.GetDB();
            }
        }

        public DataTable GetDetailById(string id)
        {
            StorageDetailDAO dao = new StorageDetailDAO();
            DataTable storageDetails = dao.GetDetailById(id);
            return storageDetails;
        }
        public void UpdateQuantity(StorageDetailDTO dto)
        {
            SetTableData();
            int flag = 1;
            StorageDetailDAO dao = new StorageDetailDAO();
            foreach (DataRow row in storageDetailList.Rows)
            {
                if (row["MaSP"].Equals(dto.productID) && row["MaKho"].Equals(dto.storageID))
                {
                    flag = 0;
                    int quantity = int.Parse(row["SOLUONG"].ToString()) + int.Parse(dto.productQuantity);
                    dto.productQuantity = quantity.ToString();
                    dao.UpdateQuantity(dto);
                    break;
                }
            }
            if (flag == 1)
            {
                dao.InsertNewProduct(dto);
            }
            storageDetailList.Clear();
            SetTableData();
        }
    }
}
