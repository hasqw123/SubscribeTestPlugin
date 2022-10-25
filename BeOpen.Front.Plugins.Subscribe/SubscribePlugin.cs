using Newtonsoft.Json;
using Resto.Front.Api;
using Resto.Front.Api.Attributes;
using Resto.Front.Api.Attributes.JetBrains;
using System;
using System.Threading;
using System.Collections.Generic;

namespace BeOpen.Front.Subscribe
{
    using static PluginContext;

    [UsedImplicitly]
    [PluginLicenseModuleId(21016318)]
    public sealed class SubscribePlugin : IFrontPlugin
    {
        private List<IDisposable> Subscribers { get; }

        public SubscribePlugin()
        {
            var formatJson = Formatting.None;
            var settingsJson = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

            Subscribers = new List<IDisposable>()
            {

                Notifications.BeforeDeleteNonPrintedItems.Subscribe( obj =>
                {
                    Log.Info("SubscribeBeforeDeleteNonPrintedItems");
                    Log.Info($"{obj.order}, {obj.deletingItems}, {obj.deletingModifiers}, {obj.user}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Deleting Items: {JsonConvert.SerializeObject(obj.deletingItems, formatJson, settingsJson)}");

                    Log.Info($"Deleting ModifiModifiers: {JsonConvert.SerializeObject(obj.deletingModifiers, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.BeforeDeleteOrder.Subscribe(obj =>
                {
                    Log.Info("SubscribeBeforeDeleteOrder");
                    Log.Info($"{obj.order}, {obj.user}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.BeforeDeletePrintedItems.Subscribe(obj =>
                {
                    Log.Info("SubscribeBeforeDeletePrintedItems");
                    Log.Info($"{obj.order}, {obj.deletingItems}, {obj.deletingModifiers}, {obj.dm}, {obj.user}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Deleting Items: {JsonConvert.SerializeObject(obj.deletingItems, formatJson, settingsJson)}");

                    Log.Info($"Deleting ModifiModifiers: {JsonConvert.SerializeObject(obj.deletingModifiers, formatJson, settingsJson)}");

                    Log.Info($"Dm : {JsonConvert.SerializeObject(obj.dm, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.BeforeDoCheque.Subscribe(obj =>
                {
                    Log.Info("SubscribeBeforeDoCheque");
                    Log.Info($"{obj.order}, {obj.os}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Os: {JsonConvert.SerializeObject(obj.os, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.BeforeOrderBill.Subscribe(obj =>
                {
                    Log.Info("SubscribeBeforeOrderBill");
                    Log.Info($"{obj.order}, {obj.user}, {obj.os}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");

                    Log.Info($"Os: {JsonConvert.SerializeObject(obj.os, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");

                }),

                Notifications.BeforeServiceCheque.Subscribe(obj =>
                {
                    Log.Info("SubscribeBeforeServiceCheque");
                    Log.Info($"{obj.order}, {obj.printingItems}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"PrintingItems: {JsonConvert.SerializeObject(obj.printingItems, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.BillChequePosResolving.Subscribe(obj =>
                {
                    Log.Info("SubscribeBillChequePosResolving");
                    Log.Info($"{obj.order}, {obj.isStorno}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"IsStorno: {JsonConvert.SerializeObject(obj.isStorno, formatJson, settingsJson)}");

                    return null;
                }),

                Notifications.BillChequePrinting.Subscribe(obj =>
                {

                    Log.Info("SubscribeBillChequePrinting");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");

                    return null;
                }),

                Notifications.CafeSessionChanged.Subscribe(obj=>
                {
                    Log.Info("SubscribeCafeSessionChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.CafeSessionClosing.Subscribe(obj =>
                {
                    Log.Info("SubscribeCafeSessionClosing");
                    Log.Info($"{obj.printer}, {obj.vm}");

                    Log.Info($"Printer: {JsonConvert.SerializeObject(obj.printer, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.CafeSessionOpening.Subscribe(obj =>
                {
                    Log.Info("SubscribeCafeSessionOpening");
                    Log.Info($"{obj.printer}, {obj.vm}");

                    Log.Info($"Printer: {JsonConvert.SerializeObject(obj.printer, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.CashChequePrinting.Subscribe(obj =>
                {
                    Log.Info("SubscribeCashChequePrinting");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");

                    return null;
                }),

                Notifications.ChangeSumChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeChangeSumChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.CityChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeCityChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ClientChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeClientChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.CompoundItemTemplateChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeCompoundItemTemplateChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.CurrentCultureChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeCurrentCultureChanged");
                    Log.Info($"{obj.culture}, {obj.uiCulture}");

                    Log.Info($"Culture: {JsonConvert.SerializeObject(obj.culture, formatJson, settingsJson)}");

                    Log.Info($"UiCulture: {JsonConvert.SerializeObject(obj.uiCulture, formatJson, settingsJson)}");
                }),

                Notifications.CurrentUserChanged.Subscribe(obj =>
                {

                    Log.Info("SubscribeCurrentUserChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.DeliveryCancelCauseChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeDeliveryCancelCauseChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.DeliveryOrderChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeDeliveryOrderChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");

                    if(obj.Entity.DeliveryStatus == Resto.Front.Api.Data.Brd.DeliveryStatus.OnWay)
                    {
                        try
                        {
                            Log.Info(obj.Entity.DeliveryStatus.ToString());

                            var windowThread = new Thread(() =>
                            {
                                 var windowStatusDelivery = new WindowDelivery();
                                 windowStatusDelivery.Topmost = true;
                                 windowStatusDelivery.ShowStatus(obj.Entity.Number.ToString());
                                 Thread.Sleep(10000);
                            });
                            windowThread.SetApartmentState(ApartmentState.STA);
                            windowThread.Start();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.ToString());
                        }

                    }
                }),

                Notifications.DeliverySettingsChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeDeliverySettingsChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.DiscountCardChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeDiscountCardChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.DiscountTypeChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeDiscountTypeChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.DonationTypeChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeDonationTypeChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ExternalOperationChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeExternalOperationChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.KitchenOrderChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeKitchenOrderChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.MarketingSourceChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeMarketingSourceChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.NavigatingToPaymentScreen.Subscribe(obj =>
                {
                    Log.Info("SubscribeNavigatingToPaymentScreen");
                    Log.Info($"{obj.order}, {obj.pos}, {obj.os}, {obj.vm}, {obj.context}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Pos: {JsonConvert.SerializeObject(obj.pos, formatJson, settingsJson)}");

                    Log.Info($"Os: {JsonConvert.SerializeObject(obj.os, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");

                    Log.Info($"Context: {JsonConvert.SerializeObject(obj.context, formatJson, settingsJson)}");
                }),

                Notifications.OrderBillCancelled.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderBillCancelled");
                    Log.Info($"{obj.order}, {obj.user}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");
                }),

                Notifications.OrderChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.OrderEditBarcodeScanned.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderEditBarcodeScanned");
                    Log.Info($"{obj.barcode}, {obj.order}, {obj.os}, {obj.vm}");

                    Log.Info($"Barcode: {JsonConvert.SerializeObject(obj.barcode, formatJson, settingsJson)}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Os: {JsonConvert.SerializeObject(obj.os, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");

                    return new bool();
                }),

                Notifications.OrderEditCardSlided.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderEditCardSlided");
                    Log.Info($"{obj.card}, {obj.order}, {obj.os}, {obj.vm}");

                    Log.Info($"Card: {JsonConvert.SerializeObject(obj.card, formatJson, settingsJson)}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Os: {JsonConvert.SerializeObject(obj.os, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");

                    return new bool();
                }),

                Notifications.OrderSplittedByCashRegisters.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderSplittedByCashRegisters");
                    Log.Info($"{obj.order}, {obj.newOrderIds}, {obj.user}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"NewOrderIds: {JsonConvert.SerializeObject(obj.newOrderIds, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");
                }),

                Notifications.OrderStorned.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderStorned");
                    Log.Info($"{obj.order}, {obj.newOrderId}, {obj.user}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"NewOrderId: {JsonConvert.SerializeObject(obj.newOrderId, formatJson, settingsJson)}");

                    Log.Info($"User: {JsonConvert.SerializeObject(obj.user, formatJson, settingsJson)}");
                }),

                Notifications.OrderTypeChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderTypeChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.PaymentScreenUpdated.Subscribe(obj =>
                {
                    Log.Info("SubscribePaymentScreenUpdated");
                    Log.Info($"{obj.context}, {obj.vm}");

                    Log.Info($"Context: {JsonConvert.SerializeObject(obj.context, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");
                }),

                Notifications.PaymentTypeChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeOrderPaymentTypeChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.PreliminaryOrderChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribePreliminaryOrderChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.PriceCategoryChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribePriceCategoryChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductCategoryChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductCategoryChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductGroupChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductGroupChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductScaleChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductScaleChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductSizeChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductSizeChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductsRemainingAmountsChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductsRemainingAmountsChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ProductStocksListChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeProductsProductStocksListChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.QuickMenuUpdated.Subscribe(obj =>
                {
                    Log.Info("SubscribeQuickMenuUpdated");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.RegionChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeRegionChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.RemovalTypeChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeRemovalTypeChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ReserveChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeReserveChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.RestaurantChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeReserveChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.RestaurantSectionChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeRestaurantSectionChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.RoleChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeRestaurantSectionChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ScreenChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeScreenChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.ServiceChequePrinted.Subscribe(obj =>
                {
                    Log.Info("SubscribeServiceChequePrinted");
                    Log.Info($"{obj.order}, {obj.os}, {obj.vm}");

                    Log.Info($"Order: {JsonConvert.SerializeObject(obj.order, formatJson, settingsJson)}");

                    Log.Info($"Os: {JsonConvert.SerializeObject(obj.os, formatJson, settingsJson)}");

                    Log.Info($"Vm: {JsonConvert.SerializeObject(obj.vm, formatJson, settingsJson)}");

                }),

                Notifications.StreetChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeStreetChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.TableChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeTableChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.TaxCategoryChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeTaxCategoryChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.TerminalChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeTerminalChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.TerminalsGroupChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeTerminalsGroupChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.UserChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeUserChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                }),

                Notifications.UserSessionChanged.Subscribe(obj =>
                {
                    Log.Info("SubscribeUserSessionChanged");
                    Log.Info($"{obj}");

                    Log.Info($"{JsonConvert.SerializeObject(obj, formatJson, settingsJson)}");
                })
            };
            Log.Info(Subscribers.Count.ToString());
        }

        public void Dispose()
        {
            foreach (var x in Subscribers)
            {
                x.Dispose();
            }
        }
    }

}



