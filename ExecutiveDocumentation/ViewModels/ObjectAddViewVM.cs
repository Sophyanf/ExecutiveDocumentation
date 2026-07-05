using ExecutiveDocumentation.Controllers;
using ExecutiveDocumentation.Enums;
using ExecutiveDocumentation.Models;
using ExecutiveDocumentation.Views;
using Microsoft.Office.Interop.Excel;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Application = System.Windows.Application;
using Window = System.Windows.Window;

namespace ExecutiveDocumentation.ViewModels   // <-- только один раз
{
    public class ObjectAddViewVM : BaseViewModel
        {
            #region Properties

            // --- Существующие поля (оставляем как было) ---
            private string objName = string.Empty;
            public string ObjName
            {
                get => objName;
                set => UpdateValue(ref objName, value);
            }

            private Adress objAdress;
            public Adress ObjAdress
            {
                get => objAdress;
                set => UpdateValue(ref objAdress, value);
            }

            private DateTime endDate = DateTime.Now.AddDays(30);
            public DateTime EndDate
            {
                get => endDate;
                set => UpdateValue(ref endDate, value);
            }

            private int costOfObject;
            public int CostOfObject
            {
                get => costOfObject;
                set => UpdateValue(ref costOfObject, value);
            }

            private OriginDocumentStatus isOriginDocuments = OriginDocumentStatus.No;
            public OriginDocumentStatus IsOriginDocuments
            {
                get => isOriginDocuments;
                set => UpdateValue(ref isOriginDocuments, value);
            }

            private OriginDocumentStatus isOriginDocumentsSub = OriginDocumentStatus.No;
            public OriginDocumentStatus IsOriginDocumentsSub
            {
                get => isOriginDocumentsSub;
                set => UpdateValue(ref isOriginDocumentsSub, value);
            }

            public StatusOfObject Status => StatusOfObject.InWork;

            private TypeOfObject? typeOfObject;
            public TypeOfObject? TypeOfObject
            {
                get => typeOfObject;
                set => UpdateValue(ref typeOfObject, value);
            }

            private ResponsiblPerson? customerOrgRespPerson;
            public ResponsiblPerson? CustomerOrgRespPerson
            {
                get => customerOrgRespPerson;
                set => UpdateValue(ref customerOrgRespPerson, value);
            }

            private Kontragent? constructionOrganization;
            public Kontragent? ConstructionOrganization
            {
                get => constructionOrganization;
                set => UpdateValue(ref constructionOrganization, value);
            }

            private Kontragent? constructionOrganizationSub;
            public Kontragent? ConstructionOrganizationSub
            {
                get => constructionOrganizationSub;
                set => UpdateValue(ref constructionOrganizationSub, value);
            }

            private Kontragent? customer;
            public Kontragent? Customer
            {
                get => customer;
                set => UpdateValue(ref customer, value);
            }


            // --- Новый блок: Contract ---

            // Список контрактов для ComboBox
            private ObservableCollection<Contract> contractsList = new ObservableCollection<Contract>();
            public ObservableCollection<Contract> ContractsList
            {
                get => contractsList;
                set => UpdateValue(ref contractsList, value);
            }

            // Выбранный контракт (то, что пойдёт в ConstructionObject)
            private Contract? contract;
            public Contract? Contract
            {
                get => contract;
                set => UpdateValue(ref contract, value);
            }

            #endregion

            #region Commands

            public ActionCommand AddNewConctrObject { get; set; }

            public ObjectAddViewVM()
            {
                AddNewConctrObject = new ActionCommand(x => AddNewObjectAsync());

                Kontragents = new ObservableCollection<Kontragent>();
                LoadKontragents();

                ContractsList = new ObservableCollection<Contract>();
                LoadContracts();

                // Если нужно сразу подставить какого-то подрядчика
                ConstructionOrganization = Kontragents.FirstOrDefault(k => k.KontragentShortName == "НовГазМонтаж");
            }

            #endregion

            private void LoadContracts()
            {
                // Здесь ты подключаешь свою логику загрузки (EF6 / EF Core / репозиторий)
                // Пример для EF6 (т.к. ты работал с EF6):
                using (var ctx = new AppDbContext())
                {
                    var items = ctx.Contracts
                        .OrderBy(c => c.ContractNumber)
                        .ToList();

                    ContractsList.Clear();
                    foreach (var c in items)
                    {
                        ContractsList.Add(c);
                    }
                }
            }

            private async Task AddNewObjectAsync()
            {
                if (string.IsNullOrWhiteSpace(ObjName))
                {
                    MessageBox.Show("Введите наименование объекта.");
                    return;
                }

                if (Customer == null)
                {
                    MessageBox.Show("Выберите заказчика из списка.");
                    return;
                }

                var newObject = new ConstructionObject
                {
                    ObjectName = ObjName,
                    ObjectAdress = ObjAdress,
                    EndDate = EndDate,
                    CostOfObject = CostOfObject,

                    Status = Status,
                    IsOriginDocuments = IsOriginDocuments,
                    IsOriginDocumentsSub = IsOriginDocumentsSub,

                    TypeOfObject = TypeOfObject,
                    CustomerOrgRespPerson = CustomerOrgRespPerson,

                    ConstructionOrganization = ConstructionOrganization,
                    ConstructionOrganizationSub = ConstructionOrganizationSub,
                    Customer = Customer,

                    Contract = Contract  // <-- вот тут мы сохраняем выбранный контракт
                };

                try
                {
                    bool result = await Task.Run(() => dataObjAdd.AddObjectAsync(newObject, Customer));
                    if (result)
                    {
                        MessageBox.Show("Объект успешно создан!");
                        CloseCurrentWindow();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось сохранить объект. Проверьте логи.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }

            private void CloseCurrentWindow()
            {
                var activeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
                if (activeWindow != null)
                {
                    activeWindow.Close();
                }
            }
        }
    }


