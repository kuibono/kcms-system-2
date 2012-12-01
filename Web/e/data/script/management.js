var template = '<span style="color:{0};">{1}</span>';

var change = function (value) {
    return String.format(template, (value == true) ? "green" : "red", value);
};

var pctChange = function (value) {
    return String.format(template, (value > 0) ? "green" : "red", value + "%");
};


/* 
*
搜索框输入事件
*
*/
var keyUp = function (el, e) {
    var text = this.getRawValue();

    if (Ext.isEmpty(text, false)) {
        clearFilter(el);
    }

    //            if (text.length < 3) {
    //                return;
    //            }

    //server.BindData();

    if (Ext.isEmpty(text, false)) {
        return;
    }

    el.triggers[0].show();

    if (e.getKey() === Ext.EventObject.ESC) {
        clearFilter(el);
    } else {
        var re = new RegExp(".*" + text + ".*", "i");
    }
};


var clearFilter = function (el, trigger, index, e) {
    el.setValue("");
    el.triggers[0].hide();
    el.focus(false, 100);
    server.BindData();
};

var filterSpecialKey = function (field, e) {
    if (e.getKey() == e.DOWN) {
        var n = exampleTree.getRootNode().findChildBy(function (node) {
            return node.isLeaf() && !node.hidden;
        }, exampleTree, true);

        if (n) {
            n.ensureVisible(function () {
                exampleTree.getSelectionModel().select(n);
            });
        }
    }
};

/* 
*
拖动排序事件
*
*/
var notifyDrop = function (ddSource, e, data) {
    var grid = data.grid;
    var store = grid.store;
    var rows = grid.getSelectionModel().getSelections();
    var cindex = ddSource.getDragData(e).rowIndex;
    if (cindex == undefined || cindex < 0) {
        e.cancel = true;
        return;
    }

    //纪录拖放后被拖放纪录的新rowIndex
    var dragDropedRowIndexs = new Array();

    var newRowIndex = cindex;
    var total = store.getTotalCount();
    //当在选中多行拖动调整时，计算新的行索引起始位置
    if ((cindex + rows.length) > total) {
        newRowIndex = total - rows.length;
    }

    for (var i = 0; i < rows.length; i++) {
        var rowdata = store.getById(rows[i].id);
        if (!this.copy) {
            store.remove(store.getById(rows[i].id));
            store.insert(cindex, rowdata);
            dragDropedRowIndexs[i] = newRowIndex + i;


            if (parseInt(cindex + 1) < parseInt(total)) {
                /*
                *	通过这里取得拖动后的顺序，可处理自己的逻辑，比如存数据库
                */
                //拖动行的Order（原顺序）
                var hiDargId = store.getById(rows[i].id).get("Order");
                //拖动后的Order(新顺序)
                var newId = store.getAt(cindex + 1).get("Order");

                alert("id -" + store.getById(rows[i].id).get("Title") + ",to target -" + store.getAt(cindex + 1).get("Title"));



            }
        }
    }
    grid.getSelectionModel().selectRows(dragDropedRowIndexs);
};

function showErrorMsg(msg) {
    Ext.Msg.show({
        title: '错误',
        msg: msg,
        buttons: Ext.Msg.OK,
        icon: Ext.MessageBox.ERROR
    });
}

var selectedRowIndex = undefined;
/*
*	行选中事件
*参数：model:selectionModel,rowIndex:选中行索引
*/
var rowSelect = function (model, rowIndex) {
    selectedRowIndex = rowIndex;
}

function changeOrder(grid, commandName) {
    if (!grid.getSelectionModel().singleSelect) {
        showErrorMsg("使用【最上】【上移】【下移】【最下】按钮调整顺序的方式，暂只支持单选模式,！请设置:ext:RowSelectionModel ID=\"RowSelectionModel1\" SingleSelect=\"<b>true</b>\" runat=\"server\"");
        return;
    }

    //获取选中行
    var selectedRow = grid.getSelectionModel().getSelected();
    //如果没有选中行，提示错误
    if (!selectedRow) {
        showErrorMsg("请选中要调整顺序的行！");
        return;
    }

    var cindex = undefined;
    var store = grid.getStore();
    var total = store.getTotalCount();

    store.remove(selectedRow);
    switch (commandName) {
        case "top":
            cindex = 0;
            store.insert(cindex, selectedRow);
            break;
        case "bottom":
            cindex = total - 1;
            store.insert(cindex, selectedRow);
            break;
        case "up":
            if (selectedRowIndex != undefined && selectedRowIndex > 0) {
                cindex = selectedRowIndex - 1;
                store.insert(cindex, selectedRow);
            }
            else {
                cindex = 0;
                store.insert(cindex, selectedRow);
            }
            break;
        case "down":
            if (selectedRowIndex != undefined && selectedRowIndex < total - 1) {
                cindex = selectedRowIndex + 1;
                store.insert(cindex, selectedRow);
            }
            else {
                cindex = total - 1;
                store.insert(cindex, selectedRow);
            }
            break;
        default:
            showErrorMsg("没有找到正确的CommandName!");
    }
    //重新选中行
    grid.getSelectionModel().selectRow(cindex);
}



function AdvanceSearch(obj, state) {
    if (state == true) {
        advForm.show();
    }
    else {
        advForm.hide();
    }
}


