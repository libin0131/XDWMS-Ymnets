//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Apps.Models;
using Apps.Common;
using Unity.Attributes;
using System.Transactions;
using Apps.BLL.Core;
using Apps.Locale;
using LinqToExcel;
using System.IO;
using System.Text;
using Apps.IDAL.WMS;
using Apps.Models.WMS;
using Apps.IBLL.WMS;
namespace Apps.BLL.WMS
{
	public partial class WMS_ReturnOrderBLL: Virtual_WMS_ReturnOrderBLL,IWMS_ReturnOrderBLL
	{
        

	}
	public class Virtual_WMS_ReturnOrderBLL
	{
        [Dependency]
        public IWMS_ReturnOrderRepository m_Rep { get; set; }

		public virtual List<WMS_ReturnOrderModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<WMS_ReturnOrder> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								
								a=>a.ReturnOrderNum.Contains(queryStr)
								
								
								
								
								
								
								|| a.Lot.Contains(queryStr)
								
								
								|| a.Status.Contains(queryStr)
								|| a.Remark.Contains(queryStr)
								|| a.PrintStaus.Contains(queryStr)
								
								|| a.PrintMan.Contains(queryStr)
								|| a.ConfirmStatus.Contains(queryStr)
								|| a.ConfirmMan.Contains(queryStr)
								
								|| a.Attr1.Contains(queryStr)
								|| a.Attr2.Contains(queryStr)
								|| a.Attr3.Contains(queryStr)
								|| a.Attr4.Contains(queryStr)
								|| a.Attr5.Contains(queryStr)
								|| a.CreatePerson.Contains(queryStr)
								
								|| a.ModifyPerson.Contains(queryStr)
								
								
								|| a.ReturnOderType.Contains(queryStr)
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

		public virtual List<WMS_ReturnOrderModel> GetListByUserId(ref GridPager pager, string userId,string queryStr)
		{
			return new List<WMS_ReturnOrderModel>();
		}
		
		public virtual List<WMS_ReturnOrderModel> GetListByParentId(ref GridPager pager, string queryStr,object parentId)
        {
			return new List<WMS_ReturnOrderModel>();
		}

        public virtual List<WMS_ReturnOrderModel> CreateModelList(ref IQueryable<WMS_ReturnOrder> queryData)
        {

            List<WMS_ReturnOrderModel> modelList = (from r in queryData
                                              select new WMS_ReturnOrderModel
                                              {
													Id = r.Id,
													ReturnOrderNum = r.ReturnOrderNum,
													AIID = r.AIID,
													ReInspectID = r.ReInspectID,
													PartID = r.PartID,
													SupplierId = r.SupplierId,
													InvId = r.InvId,
													SubInvId = r.SubInvId,
													Lot = r.Lot,
													ReturnQty = r.ReturnQty,
													AdjustQty = r.AdjustQty,
													Status = r.Status,
													Remark = r.Remark,
													PrintStaus = r.PrintStaus,
													PrintDate = r.PrintDate,
													PrintMan = r.PrintMan,
													ConfirmStatus = r.ConfirmStatus,
													ConfirmMan = r.ConfirmMan,
													ConfirmDate = r.ConfirmDate,
													Attr1 = r.Attr1,
													Attr2 = r.Attr2,
													Attr3 = r.Attr3,
													Attr4 = r.Attr4,
													Attr5 = r.Attr5,
													CreatePerson = r.CreatePerson,
													CreateTime = r.CreateTime,
													ModifyPerson = r.ModifyPerson,
													ModifyTime = r.ModifyTime,
													BatchId = r.BatchId,
													ReturnOderType = r.ReturnOderType,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, WMS_ReturnOrderModel model)
        {
            try
            {
                WMS_ReturnOrder entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Resource.PrimaryRepeat);
                    return false;
                }
                entity = new WMS_ReturnOrder();
               				entity.Id = model.Id;
				entity.ReturnOrderNum = model.ReturnOrderNum;
				entity.AIID = model.AIID;
				entity.ReInspectID = model.ReInspectID;
				entity.PartID = model.PartID;
				entity.SupplierId = model.SupplierId;
				entity.InvId = model.InvId;
				entity.SubInvId = model.SubInvId;
				entity.Lot = model.Lot;
				entity.ReturnQty = model.ReturnQty;
				entity.AdjustQty = model.AdjustQty;
				entity.Status = model.Status;
				entity.Remark = model.Remark;
				entity.PrintStaus = model.PrintStaus;
				entity.PrintDate = model.PrintDate;
				entity.PrintMan = model.PrintMan;
				entity.ConfirmStatus = model.ConfirmStatus;
				entity.ConfirmMan = model.ConfirmMan;
				entity.ConfirmDate = model.ConfirmDate;
				entity.Attr1 = model.Attr1;
				entity.Attr2 = model.Attr2;
				entity.Attr3 = model.Attr3;
				entity.Attr4 = model.Attr4;
				entity.Attr5 = model.Attr5;
				entity.CreatePerson = model.CreatePerson;
				entity.CreateTime = model.CreateTime;
				entity.ModifyPerson = model.ModifyPerson;
				entity.ModifyTime = model.ModifyTime;
				entity.BatchId = model.BatchId;
				entity.ReturnOderType = model.ReturnOderType;
  

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }



         public virtual bool Delete(ref ValidationErrors errors, object id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, object[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

		
       

        public virtual bool Edit(ref ValidationErrors errors, WMS_ReturnOrderModel model)
        {
            try
            {
                WMS_ReturnOrder entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Resource.Disable);
                    return false;
                }
                              				entity.Id = model.Id;
				entity.ReturnOrderNum = model.ReturnOrderNum;
				entity.AIID = model.AIID;
				entity.ReInspectID = model.ReInspectID;
				entity.PartID = model.PartID;
				entity.SupplierId = model.SupplierId;
				entity.InvId = model.InvId;
				entity.SubInvId = model.SubInvId;
				entity.Lot = model.Lot;
				entity.ReturnQty = model.ReturnQty;
				entity.AdjustQty = model.AdjustQty;
				entity.Status = model.Status;
				entity.Remark = model.Remark;
				entity.PrintStaus = model.PrintStaus;
				entity.PrintDate = model.PrintDate;
				entity.PrintMan = model.PrintMan;
				entity.ConfirmStatus = model.ConfirmStatus;
				entity.ConfirmMan = model.ConfirmMan;
				entity.ConfirmDate = model.ConfirmDate;
				entity.Attr1 = model.Attr1;
				entity.Attr2 = model.Attr2;
				entity.Attr3 = model.Attr3;
				entity.Attr4 = model.Attr4;
				entity.Attr5 = model.Attr5;
				entity.CreatePerson = model.CreatePerson;
				entity.CreateTime = model.CreateTime;
				entity.ModifyPerson = model.ModifyPerson;
				entity.ModifyTime = model.ModifyTime;
				entity.BatchId = model.BatchId;
				entity.ReturnOderType = model.ReturnOderType;
 


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.NoDataChange);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

      

        public virtual WMS_ReturnOrderModel GetById(object id)
        {
            if (IsExists(id))
            {
                WMS_ReturnOrder entity = m_Rep.GetById(id);
                WMS_ReturnOrderModel model = new WMS_ReturnOrderModel();
                              				model.Id = entity.Id;
				model.ReturnOrderNum = entity.ReturnOrderNum;
				model.AIID = entity.AIID;
				model.ReInspectID = entity.ReInspectID;
				model.PartID = entity.PartID;
				model.SupplierId = entity.SupplierId;
				model.InvId = entity.InvId;
				model.SubInvId = entity.SubInvId;
				model.Lot = entity.Lot;
				model.ReturnQty = entity.ReturnQty;
				model.AdjustQty = entity.AdjustQty;
				model.Status = entity.Status;
				model.Remark = entity.Remark;
				model.PrintStaus = entity.PrintStaus;
				model.PrintDate = entity.PrintDate;
				model.PrintMan = entity.PrintMan;
				model.ConfirmStatus = entity.ConfirmStatus;
				model.ConfirmMan = entity.ConfirmMan;
				model.ConfirmDate = entity.ConfirmDate;
				model.Attr1 = entity.Attr1;
				model.Attr2 = entity.Attr2;
				model.Attr3 = entity.Attr3;
				model.Attr4 = entity.Attr4;
				model.Attr5 = entity.Attr5;
				model.CreatePerson = entity.CreatePerson;
				model.CreateTime = entity.CreateTime;
				model.ModifyPerson = entity.ModifyPerson;
				model.ModifyTime = entity.ModifyTime;
				model.BatchId = entity.BatchId;
				model.ReturnOderType = entity.ReturnOderType;
 
                return model;
            }
            else
            {
                return null;
            }
        }


		 /// <summary>
        /// 校验Excel数据,这个方法一般用于重写校验逻辑
        /// </summary>
        public virtual bool CheckImportData(string fileName, List<WMS_ReturnOrderModel> list,ref ValidationErrors errors )
        {
          
            var targetFile = new FileInfo(fileName);

            if (!targetFile.Exists)
            {

                errors.Add("导入的数据文件不存在");
                return false;
            }

            var excelFile = new ExcelQueryFactory(fileName);

            //对应列头
			 				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ReturnOrderNum, "退货单号");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.AIID, "到货检验单ID");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ReInspectID, "重新送检单ID");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.PartID, "物料编码");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.SupplierId, "代理商编码");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.InvId, "库存编码");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.SubInvId, "SubInvId");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Lot, "Lot");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ReturnQty, "应退货数量");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.AdjustQty, "实际退货数量");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Status, "单据状态:有效/无效");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Remark, "退货说明");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.PrintStaus, "打印状态");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.PrintDate, "打印时间");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.PrintMan, "打印人");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ConfirmStatus, "确认状态");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ConfirmMan, "确认人");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ConfirmDate, "确认时间");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Attr1, "Attr1");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Attr2, "Attr2");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Attr3, "Attr3");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Attr4, "Attr4");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.Attr5, "Attr5");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.CreatePerson, "创建人");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.CreateTime, "创建时间");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ModifyPerson, "修改人");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ModifyTime, "修改时间");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.BatchId, "BatchId");
				 excelFile.AddMapping<WMS_ReturnOrderModel>(x => x.ReturnOderType, "退货单类型");
 
            //SheetName
            var excelContent = excelFile.Worksheet<WMS_ReturnOrderModel>(0);
            int rowIndex = 1;
            //检查数据正确性
            foreach (var row in excelContent)
            {
                var errorMessage = new StringBuilder();
                var entity = new WMS_ReturnOrderModel();
						 				  entity.Id = row.Id;
				  entity.ReturnOrderNum = row.ReturnOrderNum;
				  entity.AIID = row.AIID;
				  entity.ReInspectID = row.ReInspectID;
				  entity.PartID = row.PartID;
				  entity.SupplierId = row.SupplierId;
				  entity.InvId = row.InvId;
				  entity.SubInvId = row.SubInvId;
				  entity.Lot = row.Lot;
				  entity.ReturnQty = row.ReturnQty;
				  entity.AdjustQty = row.AdjustQty;
				  entity.Status = row.Status;
				  entity.Remark = row.Remark;
				  entity.PrintStaus = row.PrintStaus;
				  entity.PrintDate = row.PrintDate;
				  entity.PrintMan = row.PrintMan;
				  entity.ConfirmStatus = row.ConfirmStatus;
				  entity.ConfirmMan = row.ConfirmMan;
				  entity.ConfirmDate = row.ConfirmDate;
				  entity.Attr1 = row.Attr1;
				  entity.Attr2 = row.Attr2;
				  entity.Attr3 = row.Attr3;
				  entity.Attr4 = row.Attr4;
				  entity.Attr5 = row.Attr5;
				  entity.CreatePerson = row.CreatePerson;
				  entity.CreateTime = row.CreateTime;
				  entity.ModifyPerson = row.ModifyPerson;
				  entity.ModifyTime = row.ModifyTime;
				  entity.BatchId = row.BatchId;
				  entity.ReturnOderType = row.ReturnOderType;
 
                //=============================================================================
                if (errorMessage.Length > 0)
                {
                    errors.Add(string.Format(
                        "第 {0} 列发现错误：{1}{2}",
                        rowIndex,
                        errorMessage,
                        "<br/>"));
                }
                list.Add(entity);
                rowIndex += 1;
            }
            if (errors.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public virtual void SaveImportData(IEnumerable<WMS_ReturnOrderModel> list)
        {
            try
            {
                using (DBContainer db = new DBContainer())
                {
                    foreach (var model in list)
                    {
                        WMS_ReturnOrder entity = new WMS_ReturnOrder();
                       						entity.Id = 0;
						entity.ReturnOrderNum = model.ReturnOrderNum;
						entity.AIID = model.AIID;
						entity.ReInspectID = model.ReInspectID;
						entity.PartID = model.PartID;
						entity.SupplierId = model.SupplierId;
						entity.InvId = model.InvId;
						entity.SubInvId = model.SubInvId;
						entity.Lot = model.Lot;
						entity.ReturnQty = model.ReturnQty;
						entity.AdjustQty = model.AdjustQty;
						entity.Status = model.Status;
						entity.Remark = model.Remark;
						entity.PrintStaus = model.PrintStaus;
						entity.PrintDate = model.PrintDate;
						entity.PrintMan = model.PrintMan;
						entity.ConfirmStatus = model.ConfirmStatus;
						entity.ConfirmMan = model.ConfirmMan;
						entity.ConfirmDate = model.ConfirmDate;
						entity.Attr1 = model.Attr1;
						entity.Attr2 = model.Attr2;
						entity.Attr3 = model.Attr3;
						entity.Attr4 = model.Attr4;
						entity.Attr5 = model.Attr5;
						entity.CreatePerson = model.CreatePerson;
						entity.CreateTime = ResultHelper.NowTime;
						entity.ModifyPerson = model.ModifyPerson;
						entity.ModifyTime = model.ModifyTime;
						entity.BatchId = model.BatchId;
						entity.ReturnOderType = model.ReturnOderType;
 
                        db.WMS_ReturnOrder.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
		public virtual bool Check(ref ValidationErrors errors, object id,int flag)
        {
			return true;
		}

        public virtual bool IsExists(object id)
        {
            return m_Rep.IsExist(id);
        }
		
		public void Dispose()
        { 
            
        }

	}
}
