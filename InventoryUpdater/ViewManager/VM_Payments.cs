using Common;
using Decoders;
using Decoders.Interfaces;
using SellerSense.Helper;
using SellerSense.Model;
using SellerSense.Model.Payments;
using SellerSense.Views.Payments;
using ssViewControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellerSense.ViewManager
{
    internal class VM_Payments :IManageUserControl
    {
        private PaymentsView _v_PaymentsCntrl;
        private M_Payments _m_Payments;
        private M_Product _m_product_Model;
        private Dictionary<string, Image> _images;



        public void AssignView(UserControl invUserControl)
        {
            _v_PaymentsCntrl = invUserControl as PaymentsView;
            //var emptyRow = new List<PaymentsViewDataAmz>();
            //emptyRow.Add(new PaymentsViewDataAmz() { Amount = default, AmountDesc = default, AmountType = default, Image = default, InHouseCode = default, OrderId = default, OrderItemCode = default, PostedDateTime = default, QuantityPurchased = default, ShipmentId = default, Sku = default });
            //_ssGridViewAmz = new ssGridView<PaymentsViewDataAmz>(emptyRow);_ssGridViewAmz.ReBind_Bindings();
            //AddGridControls();
            HandleProductControlEvents();
        }

        

        public VM_Payments(M_Payments payments, M_Product product_Model)
        {
            _m_Payments = payments;
            _m_product_Model = product_Model;
            _paymentsViewAmz = new ObservableCollection<PaymentsViewDataAmz>();
            _paymentsViewFk = new ObservableCollection<PaymentsViewDataFk>();
            _paymentsViewSpd = new ObservableCollection<PaymentsViewDataSpd>();
        }

        private void HandleProductControlEvents()
        {
            _v_PaymentsCntrl.button_Load_Snp_Payments.Click += async (s, e) => {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _v_PaymentsCntrl.progressBar_snapdeal.Visible = true;
                    await _m_Payments.GetSpdPayments(openFileDialog.FileName);
                    AssignSpdPaymentsToView();
                    AssignSpdInhouseCodes();
                    AssignImagesToProducts(Constants.Company.Snapdeal);
                    SortSpdPaymentsView();
                    _v_PaymentsCntrl.progressBar_snapdeal.Visible = false;
                    _ssGridViewSpd = new ssGrid.ssGridView<PaymentsViewDataSpd>(_paymentsViewSpd);
                    //_ssGridViewFk = new ssGridView<PaymentsViewDataFk>(_paymentsViewFk, true, false, "Order Id", "SKU");
                    AddSpdGridControls();
                }
            };

            _v_PaymentsCntrl.checkBox_snapdeal_consolidate.Click += (s, e) =>
            {
                if (_v_PaymentsCntrl.checkBox_snapdeal_consolidate.Checked)
                { ConsolidateSpdOrderCalculations(); }
                else
                {
                    if (consolidatedPaymentViewSpd != null && consolidatedPaymentViewSpd.Count > 0)
                        consolidatedPaymentViewSpd.Clear();
                    _ssGridViewSpd.Dispose();
                    _ssGridViewSpd = new ssGrid.ssGridView<PaymentsViewDataSpd>(_paymentsViewSpd);
                    HandleSpdGridEvents();
                    AddSpdGridControls();
                    _ssGridViewSpd.UpdateBindings();

                }
            };

            _v_PaymentsCntrl.button_Load_Fkp_Payments.Click += async (s, e) => { 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _v_PaymentsCntrl.progressBar_Fk.Visible = true;
                await _m_Payments.GetFkPayments(openFileDialog.FileName);
                AssignFkPaymentsToView();
                AssignFkInhouseCodes();
                _v_PaymentsCntrl.progressBar_Fk.Visible = false;
                AssignImagesToProducts(Constants.Company.Flipkart);
                _ssGridViewFk = new ssGrid.ssGridView<PaymentsViewDataFk>(_paymentsViewFk);
                //_ssGridViewFk = new ssGridView<PaymentsViewDataFk>(_paymentsViewFk, true, false, "Order Id", "SKU");
                AddFkGridControls();
            }
            };
            

            _v_PaymentsCntrl.button_Load_Amz_Payments.Click += async (s, e) => {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _v_PaymentsCntrl.progressBar_Fk.Visible = true;
                await _m_Payments.GetAmzPayments(openFileDialog.FileName);
                AssignAmzAmzPaymentsToView();
                AssignAmzInhouseCodes();
                _v_PaymentsCntrl.progressBar_Fk.Visible = false;
                AssignImagesToProducts(Constants.Company.Amazon);
                SortAmzPaymentsView();
                _ssGridViewAmz = new ssGrid.ssGridView<PaymentsViewDataAmz>(_paymentsViewAmz);
                HandleAmzGridEvents();
                AddAmzGridControls();
            }

            };


#if IncludeMeesho
            _v_PaymentsCntrl.button_Load_Meesho_Payments.Click += (s, e) => { };
#endif
            _v_PaymentsCntrl.checkBox_amz_consolidate.Click += (s, e) => {
                if (_v_PaymentsCntrl.checkBox_amz_consolidate.Checked)
                    ConsolidateAmzOrderCalculations();
                else
                { if (consolidatedPaymentViewAmz != null && consolidatedPaymentViewAmz.Count > 0)
                        consolidatedPaymentViewAmz.Clear();
                    _ssGridViewAmz.Dispose();  
                    _ssGridViewAmz = new ssGrid.ssGridView<PaymentsViewDataAmz>(_paymentsViewAmz);
                    HandleAmzGridEvents();
                    AddAmzGridControls(); 
                    _ssGridViewAmz.UpdateBindings(); }
            };

          

        }

        /// <summary>
        /// Assign images to view collection.
        /// </summary>
        private void AssignImagesToProducts(Constants.Company companyCode)//Dictionary<string, Image> imgs)
        {
            try
            {

                if (companyCode == Constants.Company.Amazon)
                {
                    foreach (var item in _paymentsViewAmz)
                    {
                        if (item.InHouseCode != null && _images.ContainsKey(item.InHouseCode))
                            item.Image = _images[item.InHouseCode];
                    }
                }
                if (companyCode == Constants.Company.Flipkart)
                {
                    foreach (var item in _paymentsViewFk)
                    {
                        if (item.InHouseCode != null && _images.ContainsKey(item.InHouseCode))
                            item.Image = _images[item.InHouseCode];
                    }
                }
                if (companyCode == Constants.Company.Snapdeal)
                {
                    foreach (var item in _paymentsViewSpd)
                    {
                        if (item.InHouseCode != null && _images.ContainsKey(item.InHouseCode))
                            item.Image = _images[item.InHouseCode];
                    }
                }

                //foreach (var item in payments)
                //{
                //    if (item.InHouseCode != null && _images.ContainsKey(item.InHouseCode))
                //        item.Image = _images[item.InHouseCode];
                //}
            }
            catch (Exception e)
            {
                Logger.Log("Not able to assign image, AssignImagesToProducts()", Logger.LogLevel.error, false);
            }

        }

        internal void AssignPreSavedImages(Dictionary<string, Image> images)
        {
            _images = images;
        }




#region Amazon_payments

        ObservableCollection<PaymentsViewDataAmz> consolidatedPaymentViewAmz;
        private ssGrid.ssGridView<PaymentsViewDataAmz> _ssGridViewAmz;
        
        private ObservableCollection<PaymentsViewDataAmz> _paymentsViewAmz;


        private void AddAmzGridControls()
        {
            if (_ssGridViewAmz != null)
            {
                _ssGridViewAmz.Dock = DockStyle.Fill;
                _v_PaymentsCntrl.tableLayoutPanel_Amz.Controls.Add(_ssGridViewAmz, 0, 1);
                //_v_PaymentsCntrl.tableLayoutPanel_Amz.Controls[]
                _v_PaymentsCntrl.tableLayoutPanel_Amz.SetColumnSpan(_ssGridViewAmz, 3);
            }
        }

        private void HandleAmzGridEvents()
        {
            //_ssGridViewAmz.SearchTagTriggered += (b, textBoxValue, _bindedData) => {
            //    _bindedData.Clear();
            //    _paymentsViewAmz.Where(y => !string.IsNullOrEmpty(y.OrderId)).ToList().Where((x) =>
            //    x.OrderId.ToLower().Contains(textBoxValue.ToLower())).ToList().
            //        ForEach(p => _bindedData.Add(p)
            //        );
            //};

            //_ssGridViewAmz.SearchTitleTriggered += (b, textBoxValue, _bindedData) => {
            //    _bindedData.Clear();
            //    _paymentsViewAmz.Where(y => !string.IsNullOrEmpty(y.Sku)).ToList().Where((x) =>
            //    x.Sku.ToLower().Contains(textBoxValue.ToLower())).ToList().
            //        ForEach(p => _bindedData.Add(p)
            //        );
            //};


        }

        private void SortAmzPaymentsView()
        {
            var groupedOrdersPaymentView = new ObservableCollection<PaymentsViewDataAmz>();
            // Group the orders by OrderId
            var groupedOrders = _paymentsViewAmz.GroupBy(order => order.OrderId);

            // Iterate through the groups and add the results
            foreach (var group in groupedOrders)
            {
                foreach (var order in group)
                {
                    groupedOrdersPaymentView.Add(order);
                }
            }
            _paymentsViewAmz = groupedOrdersPaymentView;
        }

        private void ConsolidateAmzOrderCalculations()
        {
            consolidatedPaymentViewAmz = new ObservableCollection<PaymentsViewDataAmz>();
            decimal costValue = 0;
            foreach (var item in _paymentsViewAmz)
            {
                PaymentsViewDataAmz paymentsViewDataAmz = new PaymentsViewDataAmz();
                DeepCopyAmzRecord(paymentsViewDataAmz,item);
                if (consolidatedPaymentViewAmz.Count() == 0 && !string.IsNullOrEmpty(paymentsViewDataAmz.OrderId))
                { consolidatedPaymentViewAmz.Add(paymentsViewDataAmz); } //add first order line.
                else if (!string.IsNullOrEmpty(paymentsViewDataAmz.OrderId) && consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].OrderId == paymentsViewDataAmz.OrderId)
                {
                    AddAllDescForOneOrder(paymentsViewDataAmz);
                    decimal preValue;
                    costValue = SumAllAmountsForOneOrder(costValue, paymentsViewDataAmz);
                    GetProfitForOrder(costValue);
                }
                else if (!string.IsNullOrEmpty(paymentsViewDataAmz.OrderId) && consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].OrderId != paymentsViewDataAmz.OrderId)
                { consolidatedPaymentViewAmz.Add(paymentsViewDataAmz); } //Another order line, with different order id
            }
            if(_ssGridViewAmz!=null ) 
                _ssGridViewAmz.Dispose();
            _ssGridViewAmz = new ssGrid.ssGridView<PaymentsViewDataAmz>(consolidatedPaymentViewAmz);
            HandleAmzGridEvents();
            AddAmzGridControls();
            _ssGridViewAmz.UpdateBindings();

            void AddAllDescForOneOrder(PaymentsViewDataAmz paymentsViewDataAmz)
            {
                consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].AmountDesc = consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].AmountDesc + " + " + paymentsViewDataAmz.AmountDesc.Trim();
            }

            decimal SumAllAmountsForOneOrder(decimal cstValue, PaymentsViewDataAmz paymentsViewDataAmz)
            {
                decimal.TryParse(consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].Amount.Trim(), out decimal preValue);
                decimal.TryParse(paymentsViewDataAmz.Amount.Trim(), out decimal thisValue);
                if (paymentsViewDataAmz.CostPrice != null) decimal.TryParse(paymentsViewDataAmz.CostPrice.Trim(), out cstValue);
                consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].Amount = (preValue + thisValue).ToString(); // add amount for current line with previous line.
                return cstValue;
            }

            void GetProfitForOrder(decimal cstValue)
            {
                decimal preValue;
                //Again convert amount to decimal for calculating profit.
                decimal.TryParse(consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].Amount.Trim(), out preValue);
                consolidatedPaymentViewAmz[consolidatedPaymentViewAmz.Count - 1].Profit = (preValue - cstValue).ToString(); //profit is latest amount - cost price
            }

        }


        private void DeepCopyAmzRecord(PaymentsViewDataAmz paymentsViewDataAmz, PaymentsViewDataAmz item)
        {
            paymentsViewDataAmz.OrderId = item.OrderId;
            paymentsViewDataAmz.ShipmentId = item.ShipmentId;
            paymentsViewDataAmz.Sku = item.Sku;
            paymentsViewDataAmz.QuantityPurchased = item.QuantityPurchased;
            paymentsViewDataAmz.CostPrice = item.CostPrice;
            paymentsViewDataAmz.InHouseCode = item.InHouseCode;
            paymentsViewDataAmz.Image = item.Image;
            paymentsViewDataAmz.OrderItemCode = item.OrderItemCode;
            paymentsViewDataAmz.PostedDateTime = item.PostedDateTime;
            paymentsViewDataAmz.AmountType = item.AmountType;
            paymentsViewDataAmz.AmountDesc = item.AmountDesc;
            paymentsViewDataAmz.Amount = item.Amount;
            paymentsViewDataAmz.Profit = item.Profit;
        }

        /// <summary>
        /// Inpects all saved products from product model collection, and gets inhousecode based on SKUs and assigns it to view collection of this form
        /// </summary>
        private void AssignAmzInhouseCodes()
        {
            foreach (var item in _paymentsViewAmz)
            {
                var savedProduct = _m_product_Model._productEntries.Find(x => x.AmazonSKU == item.Sku);
                if (savedProduct != null)
                { item.InHouseCode = savedProduct.InHouseCode ?? String.Empty;
                    item.CostPrice = savedProduct.CostPrice ?? string.Empty;
                }
            }
        }

        /// <summary>
        /// Fills view collection, to bind into grid.
        /// </summary>
        private void AssignAmzAmzPaymentsToView()
        {
            _paymentsViewAmz.Clear();
            foreach (var item in _m_Payments._amzPayments)
            {
                _paymentsViewAmz.Add(new PaymentsViewDataAmz() { Sku = item.sku ?? String.Empty, 
                    Amount = item.amount ?? String.Empty, 
                    AmountDesc = item.amountDesc ?? String.Empty, 
                    AmountType = item.amountType ?? String.Empty, 
                    OrderId = item.orderId ?? String.Empty,
                    PostedDateTime = item.postedDateTime ?? String.Empty,
                    ShipmentId = item.shipmentId ?? String.Empty,
                    OrderItemCode = item.orderItemCode ?? String.Empty,
                    QuantityPurchased = item.quantityPurchased ?? String.Empty
                });
            }
        }

       


        class PaymentsViewDataAmz
        {
            public string InHouseCode { get; set; }
            private Image _image;
            public Image Image { get { return _image; } set { _image = value; } }
            public byte[] DisplayImage { get { return ImageToByteArray(_image); } }
            public string CostPrice { get; set; }
            public string Profit { get; set; }
            public string OrderId { get; set; }
            public string ShipmentId { get; set; }
            public string AmountType { get; set; }
            public string AmountDesc { get; set; }
            public string Amount { get; set; }
            public string PostedDateTime { get; set; }
            public string OrderItemCode { get; set; }
            public string Sku { get; set; }
            public string QuantityPurchased { get; set; }

            private byte[] ImageToByteArray(System.Drawing.Image imageIn)
            {
                if (imageIn == null) { return default(byte[]); }
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

#endregion


#region Flipkart_payments

        private ObservableCollection<PaymentsViewDataFk> consolidatedPaymentViewFk;
        private ssGrid.ssGridView<PaymentsViewDataFk> _ssGridViewFk;
        //private Dictionary<string, Image> _imagesFk;
        private ObservableCollection<PaymentsViewDataFk> _paymentsViewFk;

        class PaymentsViewDataFk
        {
            public string InHouseCode { get; set; }
            private Image _image;
            public Image Image { get { return _image; } set { _image = value; } }
            public byte[] DisplayImage { get { return ImageToByteArray(_image); } }
            public string CostPrice { get; set; }
            public string OrderId { get; set; }
           public  string OrderItemId { get; set; }
           public  string Sku { get; set; }
           public  string BankSettlementValue { get; set; }
           public  string Return { get; set; }
           public  string Tds { get; set; }
           public  string SaleAmount { get; set; }
           public  string TotalOfferAmt { get; set; }
           public  string MyShare { get; set; }
           public  string CustomerAddonAmt { get; set; }
           public  string MarketplaceFee { get; set; }
           public  string Taxes { get; set; }

            private byte[] ImageToByteArray(System.Drawing.Image imageIn)
            {
                if (imageIn == null) { return default(byte[]); }
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        private void AddFkGridControls()
        {
            if (_ssGridViewFk != null)
            {
                _ssGridViewFk.Dock = DockStyle.Fill;
                _v_PaymentsCntrl.tableLayoutPanel_Fk.Controls.Add(_ssGridViewFk, 0, 1);
                //_v_PaymentsCntrl.tableLayoutPanel_Amz.Controls[]
                _v_PaymentsCntrl.tableLayoutPanel_Fk.SetColumnSpan(_ssGridViewFk, 3);
            }
        }

        /// <summary>
        /// Inpects all saved products from product model collection, and gets inhousecode based on SKUs and assigns it to view collection of this form
        /// </summary>
        private void AssignFkInhouseCodes()
        {
            foreach (var item in _paymentsViewFk)
            {
                var savedProduct = _m_product_Model._productEntries.Find(x => x.FlipkartSKU == item.Sku);
                if (savedProduct != null)
                {
                    item.InHouseCode = savedProduct.InHouseCode ?? String.Empty;
                     item.CostPrice = savedProduct.CostPrice ?? string.Empty;
                }
            }
        }

        private void AssignFkPaymentsToView()
        {
            _paymentsViewFk.Clear();
            foreach (var item in _m_Payments._fkPayments)
            {
                _paymentsViewFk.Add(new PaymentsViewDataFk()
                {
                    OrderId = item.orderId ?? String.Empty,
                    OrderItemId = item.orderItemId ?? String.Empty,
                    Sku = item.sku ?? String.Empty,
                    BankSettlementValue = item.bankSettlementValue ?? String.Empty,
                    Return = item.return_type ?? String.Empty,
                    Tds = item.tds ?? String.Empty,
                    SaleAmount = item.saleAmount ?? String.Empty,
                    TotalOfferAmt = item.totalOfferAmt ?? String.Empty,
                    MyShare = item.myShare ?? String.Empty,
                    CustomerAddonAmt = item.customerAddonAmt ?? String.Empty,
                    MarketplaceFee = item.marketplaceFee ?? String.Empty,
                    Taxes = item.taxes ?? String.Empty
                });
            }
        }

#endregion


#region Snapdeal_payments

        private ObservableCollection<PaymentsViewDataSpd> consolidatedPaymentViewSpd;
        private ssGrid.ssGridView<PaymentsViewDataSpd> _ssGridViewSpd;
        //private Dictionary<string, Image> _imagesSpd;
        private ObservableCollection<PaymentsViewDataSpd> _paymentsViewSpd;


        private void AddSpdGridControls()
        {
            if (_ssGridViewSpd != null)
            {
                _ssGridViewSpd.Dock = DockStyle.Fill;
                _v_PaymentsCntrl.tableLayoutPanel_spd.Controls.Add(_ssGridViewSpd, 0, 1);
                //_v_PaymentsCntrl.tableLayoutPanel_Amz.Controls[]
                _v_PaymentsCntrl.tableLayoutPanel_spd.SetColumnSpan(_ssGridViewSpd, 3);
            }
        }


        /// <summary>
        /// Inpects all saved products from product model collection, and gets inhousecode based on SKUs and assigns it to view collection of this form
        /// </summary>
        private void AssignSpdInhouseCodes()
        {
            foreach (var item in _paymentsViewSpd)
            {
                var savedProduct = _m_product_Model._productEntries.Find((x) => !string.IsNullOrWhiteSpace(item.Sku) &&  x.SnapdealSKU == item.Sku);
                if (savedProduct != null)
                {
                    item.InHouseCode = savedProduct.InHouseCode ?? String.Empty;
                    item.CostPrice = savedProduct.CostPrice ?? string.Empty;
                }
            }
        }

        private void ConsolidateSpdOrderCalculations()
        {
            consolidatedPaymentViewSpd = new ObservableCollection<PaymentsViewDataSpd>();
            decimal costValue = 0;
            foreach (var item in _paymentsViewSpd)
            {
                PaymentsViewDataSpd paymentsViewDataSpd = new PaymentsViewDataSpd();
                DeepCopySpdRecord(paymentsViewDataSpd, item);
                if (consolidatedPaymentViewSpd.Count() == 0 && !string.IsNullOrEmpty(paymentsViewDataSpd.TransactionId))
                { consolidatedPaymentViewSpd.Add(paymentsViewDataSpd); } //add first order line.
                else if (!string.IsNullOrEmpty(paymentsViewDataSpd.TransactionId) && consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].TransactionId == paymentsViewDataSpd.TransactionId)
                {
                    //Add description of transactions types.
                    SumUpTypeOfTransactionField(paymentsViewDataSpd);
                    SumNetPayableForAllTransactionsWIthSameID(paymentsViewDataSpd);
                    SumCommisionsForAllTransactionsWIthSameID(paymentsViewDataSpd);
                    GetProfitForThisTransaction(paymentsViewDataSpd);
                }
                else if (!string.IsNullOrEmpty(paymentsViewDataSpd.TransactionId) && consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].TransactionId != paymentsViewDataSpd.TransactionId)
                { consolidatedPaymentViewSpd.Add(paymentsViewDataSpd); } //Another order line, with different order id
            }
            if (_ssGridViewSpd != null)
                _ssGridViewSpd.Dispose();
            _ssGridViewSpd = new ssGrid.ssGridView<PaymentsViewDataSpd>(consolidatedPaymentViewSpd);
            HandleSpdGridEvents();
            AddSpdGridControls();
            _ssGridViewSpd.UpdateBindings();

            //Local functions
            void SumUpTypeOfTransactionField(PaymentsViewDataSpd paymentsViewDataSpd)
            {
                consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].Type = paymentsViewDataSpd.Type + " + " + consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].Type;
            }

            void SumNetPayableForAllTransactionsWIthSameID(PaymentsViewDataSpd paymentsViewDataSpd)
            {
                decimal.TryParse(consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].NetPayable.Trim(), out decimal preValue);
                decimal.TryParse(paymentsViewDataSpd.NetPayable.Trim(), out decimal thisValue);
                consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].NetPayable = (preValue + thisValue).ToString(); // add amount for current line with previous line.
            }

            void GetProfitForThisTransaction(PaymentsViewDataSpd paymentsViewDataSpd)
            {
                decimal preValue;
                if (paymentsViewDataSpd.CostPrice != null)
                    decimal.TryParse(paymentsViewDataSpd.CostPrice.Trim(), out costValue);
                //Again convert amount to decimal for calculating profit.
                decimal.TryParse(consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].NetPayable.Trim(), out preValue);
                consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].Profit = (preValue - costValue).ToString(); //profit is latest amount - cost price
               
            }

            void SumCommisionsForAllTransactionsWIthSameID( PaymentsViewDataSpd paymentsViewDataSpd)
            {
                decimal.TryParse(paymentsViewDataSpd.Commission.Trim(), out decimal thisValue);
                decimal.TryParse(consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].Commission, out decimal preValue);
                consolidatedPaymentViewSpd[consolidatedPaymentViewSpd.Count - 1].Commission = (preValue + thisValue).ToString(); // add amount for current line with previous line.
            }
        }


        private void DeepCopySpdRecord(PaymentsViewDataSpd paymentsViewDataSpd, PaymentsViewDataSpd item)
        {
            paymentsViewDataSpd.Image = item.Image;
            paymentsViewDataSpd.TransactionId = item.TransactionId;
            paymentsViewDataSpd.TransactionDate = item.TransactionDate;
            paymentsViewDataSpd.Sku = item.Sku;
            paymentsViewDataSpd.InvoiceNumber = item.InvoiceNumber;
            paymentsViewDataSpd.CostPrice = item.CostPrice;
            paymentsViewDataSpd.InHouseCode = item.InHouseCode;
            paymentsViewDataSpd.NetPayable = item.NetPayable;
            paymentsViewDataSpd.PaymentReceicedBySpd = item.PaymentReceicedBySpd;
            paymentsViewDataSpd.Type = item.Type;
            paymentsViewDataSpd.WebSalePrice = item.WebSalePrice;
            paymentsViewDataSpd.Commission = item.Commission;
        }


        private void HandleSpdGridEvents()
        {
            //_ssGridViewSpd.SearchTagTriggered += (b, textBoxValue, _bindedData) => {
            //    _bindedData.Clear();
            //    _paymentsViewSpd.Where(y => !string.IsNullOrEmpty(y.TransactionId)).ToList().Where((x) =>
            //    x.TransactionId.ToLower().Contains(textBoxValue.ToLower())).ToList().
            //        ForEach(p => _bindedData.Add(p)
            //        );
            //};

            //_ssGridViewSpd.SearchTitleTriggered += (b, textBoxValue, _bindedData) => {
            //    _bindedData.Clear();
            //    _paymentsViewSpd.Where(y => !string.IsNullOrEmpty(y.Sku)).ToList().Where((x) =>
            //    x.Sku.ToLower().Contains(textBoxValue.ToLower())).ToList().
            //        ForEach(p => _bindedData.Add(p)
            //        );
            //};


        }

        //Groups by transaction ids, same transactions will be next to each other.
        private void SortSpdPaymentsView()
        {
            var groupedOrdersPaymentView = new ObservableCollection<PaymentsViewDataSpd>();
            // Group the orders by OrderId
            var groupedOrders = _paymentsViewSpd.GroupBy(order => order.TransactionId);

            // Iterate through the groups and add the results
            foreach (var group in groupedOrders)
            {
                foreach (var order in group)
                {
                    groupedOrdersPaymentView.Add(order);
                }
            }
            _paymentsViewSpd = groupedOrdersPaymentView;
        }


        private void AssignSpdPaymentsToView()
        {
            _paymentsViewSpd.Clear();
            foreach (var item in _m_Payments._spdPayments)
            {
                _paymentsViewSpd.Add(new PaymentsViewDataSpd()
                {
                    TransactionId = item.transactionId ?? String.Empty,
                    TransactionDate = item.transactionDate ?? String.Empty,
                    Commission = item.commission ?? String.Empty,
                    InvoiceNumber = item.invoiceNumber ?? String.Empty,
                    NetPayable = item.netPayable ?? String.Empty,
                    PaymentReceicedBySpd = item.paymentReceicedBySpd ?? String.Empty,
                    Type = item.type ?? String.Empty,   
                    WebSalePrice = item.webSalePrice ?? String.Empty,
                    Sku = item.sku ?? String.Empty

                    //OrderItemId = item.orderItemId ?? String.Empty,
                    //Sku = item.sku ?? String.Empty,
                    //BankSettlementValue = item.bankSettlementValue ?? String.Empty,
                    //Gst_tcs_Credits = item.gst_tcs_Credits ?? String.Empty,
                    //Tds = item.tds ?? String.Empty,
                    //SaleAmount = item.saleAmount ?? String.Empty,
                    //TotalOfferAmt = item.totalOfferAmt ?? String.Empty,
                    //MyShare = item.myShare ?? String.Empty,
                    //CustomerAddonAmt = item.customerAddonAmt ?? String.Empty,
                    //MarketplaceFee = item.marketplaceFee ?? String.Empty,
                    //Taxes = item.taxes ?? String.Empty
                });
            }
        }


        class PaymentsViewDataSpd
        {
            private Image _image;
            public Image Image { get { return _image; } set { _image = value; } }
            public byte[] DisplayImage { get { return ImageToByteArray(_image); } }
            public string InHouseCode { get; set; }
            //public Image Image { get; set; }
            public string CostPrice { get; set; }
            public string Profit  { get; set; }
            public string TransactionDate { get; set; }
            public string Type { get; set; }
            public string TransactionId { get; set; }
            public string Sku { get; set; }
            public string InvoiceNumber { get; set; }
            public string WebSalePrice { get; set; }
            public string PaymentReceicedBySpd { get; set; }
            public string Commission { get; set; }
            public string NetPayable { get; set; }


            private byte[] ImageToByteArray(System.Drawing.Image imageIn)
            {
                if (imageIn == null) { return default(byte[]); }
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

#endregion

    }
}
