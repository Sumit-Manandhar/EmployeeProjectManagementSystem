const pqOptions = {
    width: "auto",
    height: 300,
    showTitle: false,
    showHeader: true,
    showTop: true,
    showToolbar: false,
    showBottom: true,
    wrap: true,
    hwrap: false,
    sortable: false,
    editable: false,
    resizable: false,
    collapsible: false,
    draggable: true,
    dragColumns: { enabled: true },
    scrollModel: { autoFit: true },
    numberCell: { show: true, resizable: true, title: "S.N.", minWidth: 30 },
    pageModel: { curPage: 1, rPP: 10, type: "local" },
    columnTemplate: { wrap: true, editable: false, dataType: "string", halign: "center", hvalign: "center", resizable: true, styleHead: { 'font-weight': "bold" } },
};

function IndexVM() {
    const self = this;

    var isNullOrEmpty = function (str) {
        if (str === undefined || str === null) {
            return true;
        } else if (typeof str === "string") {
            return (str.trim() === "");
        } else {
            return false;
        }
    };

    const models = {
        Masters: function (item) {
            item = item || {};
            this.EmployeeName = ko.observable(item.EmployeeName || "");
            this.EmployeeID = ko.observable(item.EmployeeID || "");
            this.Position = ko.observable(item.Position || "");

            this.DetailsList = ko.observableArray((item.DetailsList || []).map(item => ko.toJS(new models.Details(item))));

        },

        Details: function (item) {

            item = item || {};
            this.ProjectID = ko.observable(item.ProjectID || "");
            this.ProjectName = ko.observable(item.ProjectName || "");
            this.StartDate = ko.observable(item.StartDate || "");
            this.EndDate = ko.observable(item.EndDate || "");
        },
        UiElements: function () {
            self.Masters = ko.observable(new models.Masters());
            self.Details = ko.observable(new models.Details());
            self.DataList = ko.observableArray([]);
            self.SelectedTransaction = ko.observable();

            self.ProjectList = ko.observableArray([]);
           
            self.EmployeeList = ko.observableArray([]);
             
        },
    };

    self.SaveInformation = function () {

        if (UiEvents.validate.SaveValidation()) {
                UiEvents.functions.Save(); 
                self.Masters().DetailsList.push(ko.toJS(self.Details));

        }
    };
    self.Cancel = function () {
        UiEvents.clear.ResetAll();
    }

    self.Submit = function () {

        if (UiEvents.validate.SubmitValidation()) {

            var data = ko.toJS(self.Masters());
            debugger;
            $.ajax({
                type: "POST",
                url: '/EP/Create',
                data: JSON.stringify(data),
                dataType: "json",

                contentType: "application/json; charset=utf-8",
                success: function () {

                    alert("data has been inserted successfully");
                   

                },
                error: function () {
                    console.log(data);
                    alert("Error while inserting data" + JSON.stringify(data));
                  
                }
            });

        }

    },

        self.deleteRow = function (id) {
            UiEvents.functions.Delete(id);
        };
    self.editRow = function (id) {
       
        var RowID = id;
        var selectItem = $("#Grid").pqGrid("getRowData", { rowIndxPage: Number(RowID) });
       

        self.SelectedTransaction(RowID);
        debugger;
        self.Details().ProjectID(selectItem.ProjectID);
        
        debugger;


    };



    const UiEvents = {
        validate: {
            SaveValidation: function () {
                
                if (isNullOrEmpty(self.Details().ProjectID())) {

                    alert("Warning! - project cannot be empty...!!!");
                    return false;
                }
                else if (isNullOrEmpty(self.Details().StartDate())) {
                    alert("Warning! - start date!!!");
                    return false;
                }
                else if (isNullOrEmpty(self.Details().EndDate())) {
                    alert("Warning! - ending date!!!");
                    return false;
                }
                else {

                    self.Details().ProjectName((self.ProjectList().find(X => X.Value == self.Details().ProjectID()) || {}).Text);
                    if (isNullOrEmpty(self.SelectedTransaction())) {

                        self.DataList.push(ko.toJS(self.Details()));
                    } else {

                        self.DataList.splice(self.SelectedTransaction(), 1);
                        self.DataList.push(ko.toJS(self.Details()));
                        self.SelectedTransaction('');

                    }
                    return true;
                }
            },
            SubmitValidation: function () {
                if (isNullOrEmpty(self.Masters().EmployeeID())) {

                    alert("Warning! - Employee cannot be empty...!!!");
                    return false;
                }
               else if (isNullOrEmpty(self.Details().ProjectID())) {

                    alert("Warning! - project cannot be empty...!!!");
                    return false;
                }
                else if (isNullOrEmpty(self.Details().StartDate())) {
                    alert("Warning! - start date!!!");
                    return false;
                }
                else if (isNullOrEmpty(self.Details().EndDate())) {
                    alert("Warning! - ending date!!!");
                    return false;
                }
                else {
                    self.Masters().EmployeeName((self.EmployeeList().find(X => X.Value == self.Masters().EmployeeID()) || {}).Text);
                    return true;
                }
                }
        },
        clear: {
            ResetAll: function () {
                self.Masters(new models.Masters());
                self.Details(new models.Details());
                self.DataList([]);
            },
        },
        functions: {
            Save: function () {

                if ($("#Grid").pqGrid("instance")) {
                    $("#Grid").pqGrid('option', 'dataModel.data', ko.toJS(self.DataList()));
                    $("#Grid").pqGrid('refreshDataAndView');
                } else {
                    const options = Object.assign({}, pqOptions);
                    options.colModel = [
                        { title: "type", align: "center", dataIndx: "ProjectName", width: "30%" },
                        { title: "EndDate", align: "center", dataIndx: "EndDate", width: "25%" },
                        { title: "StartDate", align: "center", dataIndx: "StartDate", width: "25%" },

                        {
                            title: "Action",
                            align: "center",
                            render: function (ui) {
                                return `<button type='button' title='Delete' class="btn btn-danger" onclick='obj.deleteRow("${ui.rowIndx}")'>Delete</button>`
                            },
                            width: "10%"
                        },
                        {
                            title: "edit",
                            align: "center",
                            render: function (ui) {
                                return `<button type='button' title='edit' class="btn btn-primary" onclick='obj.editRow("${ui.rowIndx}")'>EDIT</button>`
                            },
                            width: "10%"

                        },
                    ];
                    options.dataModel = { data: ko.toJS(self.DataList()) };
                    $("#Grid").pqGrid(options);
                }
            },
            Delete: function (index) {
                self.DataList.splice(index, 1);
                UiEvents.functions.Save();
              

            },
            loadEmployee: function () {
           
                $.ajax({
                  
                    type: "GET",
                    url: '/EP/GetEmployee',
                   
                    dataType: "json",
                    data: { id: '' },
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                     
                        $.each(data, function (i, item) {
                            self.EmployeeList.push(item);
                           

                        });
                    },
                    error: function (data) {
                        console.log(data);
                    }
                    
                })
            },
            loadProject: function () {

                $.ajax({

                    type: "GET",
                    url: '/EP/GetProject',

                    dataType: "json",
                    data: { id: '' },
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {

                        $.each(data, function (i, item) {
                            self.ProjectList.push(item);


                        });
                    },
                    error: function (data) {
                        console.log(data);
                    }

                })
            }
            
        },

    };

    function Init() {
        models.UiElements();
        UiEvents.clear.ResetAll();
        UiEvents.functions.Save();
        UiEvents.functions.loadEmployee();
        UiEvents.functions.loadProject();
    }
    Init();
}

var obj;

$(document).ready(function () {
    obj = new IndexVM();
    ko.applyBindings(obj);
    //obj.UiEvents.functions.loadEmployee();
});