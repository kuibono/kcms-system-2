<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaManagement.aspx.cs"
    Inherits="Web.e.admin.system.Basement.AreaManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地区管理</title>
    <link rel="stylesheet" type="text/css" href="../../../data/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../../data/themes/icon.css" />
    <script type="text/javascript" src="../../../data/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../../../data/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        var editingId;
        function edit() {
            if (editingId != undefined) {
                $('#tg').treegrid('select', editingId);
                $('#tg').treegrid('endEdit', editingId);
                return;
            }
            var row = $('#tg').treegrid('getSelected');
            if (row) {
                editingId = row.id
                $('#tg').treegrid('beginEdit', editingId);
            }
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table title="区域管理" class="easyui-treegrid" id="tg"
            data-options="  
                url: 'areamanagement.aspx?loadarea',  
                rownumbers: true,  
                idField: 'id',  
                treeField: 'Name',
                onClickRow:edit 
            ">
            <thead>
                <tr>
                    <th data-options="field:'Name'" width="220">
                        Name
                    </th>
                    <th data-options="field:'ShowInIndex',editor:{type:'checkbox',options:{on:'true',off:'false'}}" width="100" align="right">
                        ShowInIndex
                    </th>
                    <th data-options="field:'ShowInNav',editor:{type:'checkbox',options:{on:'true',off:'false'}}" width="150">
                        ShowInNav
                    </th>
                </tr>
            </thead>
        </table>
    </div>
    </form>
</body>
</html>
