<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Product.List" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product列表</title>
	<script type="text/javascript" src="../../data/script/management.js"></script>
    <script type="text/javascript">
        function afterEdit(e) {
            server.AfterEdit(e.record.data);
        }
        function Act(action, value, form) {
            if (action == "Delete") {
                server.DeleteItem(value.data.ID);
            }
            else {
                server.LoadForm(value.data.ID);
            }
        }
        function SaveData() {
            var values = FormPanel1.getForm().getValues();
            if (values.Audit) {
                values.Audit = true;
            }
            if (values.Tuijian) {
                values.Tuijian = true;
            }
            server.AfterEdit(values);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
	<ext:Window ID="advForm" runat="server" Height="220" Width="210" Title="高级搜索" Padding="5" AutoHeight="True" Hidden="true" Icon="DiskBlackMagnify">
        <Items>
            <ext:FormPanel ID="FormPanel2" Layout="FormLayout" HideLabels="true" Padding="5"
                runat="server">
                <Items>

					<ext:TextField ID="s_Name" DataIndex="Name" runat="server" EmptyText="产品名称" Margins="0 5 0 0" />

					<ext:TextField ID="s_Intro" DataIndex="Intro" runat="server" EmptyText="简介" Margins="0 5 0 0" />

                    <ext:ComboBox runat="server" ID="s_Enable" Editable="false" EmptyText="请选择是否可用">
                        <Items>
                            <ext:ListItem Text="不限" Value="0" />
                            <ext:ListItem Text="是" Value="true" />
                            <ext:ListItem Text="否" Value="false" />
                        </Items>
                    </ext:ComboBox>

                    <ext:ComboBox runat="server" ID="s_SetTop" Editable="false" EmptyText="请选择是否置顶">
                        <Items>
                            <ext:ListItem Text="不限" Value="0" />
                            <ext:ListItem Text="是" Value="true" />
                            <ext:ListItem Text="否" Value="false" />
                        </Items>
                    </ext:ComboBox>


                    
                </Items>
                <Buttons>
                    <ext:Button  runat="server" Text="搜索">
                        <DirectEvents>
                            <Click OnEvent="Search">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="取消">
                        <Listeners>
                            <Click Handler="#{advForm}.hide()" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="Cancel_Search">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
        <DirectEvents>
            <Close OnEvent="Cancel_Search">
                <EventMask ShowMask="true" />
            </Close>
        </DirectEvents>
    </ext:Window>
    <ext:Viewport ID="Main" runat="server" Layout="border">
        <Items>
            <ext:TabPanel ID="TabPanel1" runat="server" TabAlign="Right" Region="Center">
                <Items>
                    <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" Title="列表管理" AutoExpandColumn="Name"
						Draggable="true" DDGroup="DDGroup" EnableDragDrop="true"
                        Margins="5 5 5 5">
                        <Store>
                            <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
                                <Reader>
                                    <ext:JsonReader IDProperty="ID">
                                        <Fields>
											<ext:RecordField Name="ID" Type="Int" />
											<ext:RecordField Name="ClassName" Type="String" />
											<ext:RecordField Name="Name" Type="String" />
											<ext:RecordField Name="AddTime" Type="Date" />
											<ext:RecordField Name="Enable" Type="Boolean" />
											<ext:RecordField Name="SetTop" Type="Boolean" />
											<ext:RecordField Name="ClickCount" Type="Int" />
											<ext:RecordField Name="OrderIndex" Type="Int" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
							<Defaults>
								<ext:Parameter Name="TrueText" Value="<span style='color:green;'>是</span>" />
								<ext:Parameter Name="FalseText" Value="<span style='color:red;'>否</span>" />
							</Defaults>
                            <Columns>
                                <ext:RowNumbererColumn />
								<ext:Column Header="类名" DataIndex="ClassName"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
								<ext:Column Header="产品名称" DataIndex="Name"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
								<ext:DateColumn Header="添加时间" DataIndex="AddTime"><Editor><ext:DateField runat="server" /></Editor></ext:DateColumn>
								<ext:BooleanColumn Header="可用" DataIndex="Enable"><Editor><ext:Checkbox runat="server" /></Editor></ext:BooleanColumn>
								<ext:BooleanColumn Header="是否置顶" DataIndex="SetTop"><Editor><ext:Checkbox runat="server" /></Editor></ext:BooleanColumn>
								<ext:NumberColumn Header="点击次数" DataIndex="ClickCount"><Editor><ext:NumberField runat="server" /></Editor></ext:NumberColumn>
								<ext:NumberColumn Header="序号" DataIndex="OrderIndex"><Editor><ext:NumberField runat="server" /></Editor></ext:NumberColumn>
                                
                                <ext:CommandColumn Width="110">
                                    <Commands>
                                        <ext:GridCommand Icon="Delete" CommandName="Delete" Text="删除" />
                                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="编辑" />
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Text="每页显示:" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                    <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                        <Items>
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="20" />
                                            <ext:ListItem Text="30" />
                                            <ext:ListItem Text="50" />
                                        </Items>
                                        <SelectedItem Value="10" />
                                        <Listeners>
                                            <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="Button1" runat="server" Text="新增" Icon="Add">
										<DirectEvents>
											<Click OnEvent="Add_Click" />
										</DirectEvents>
									</ext:Button>
									<ext:Button ID="Button2" runat="server" Text="删除选中" Icon="Exclamation">
										<DirectEvents>
											<Click OnEvent="On_Remove" />
										</DirectEvents>
									</ext:Button>
									<ext:ToolbarSeparator />
									<ext:TriggerField ID="s_Key" runat="server" EmptyText="请输入关键词" EnableKeyEvents="true">
										<Triggers>
											<ext:FieldTrigger Icon="Clear" HideTrigger="true" />
										</Triggers>
										<Listeners>
											<KeyUp Fn="keyUp" Buffer="100" />
											<TriggerClick Fn="clearFilter" />
											<SpecialKey Fn="filterSpecialKey" />
										</Listeners>
									</ext:TriggerField>
									<ext:Button ID="btn_search" Text="搜索" runat="server" Icon="Zoom">
										<DirectEvents>
											<Click OnEvent="Search">
												<EventMask ShowMask="true" />
											</Click>
										</DirectEvents>
									</ext:Button>
									<ext:ToolbarSeparator />
									<ext:Button runat="server" ID="btn_Adv" Text="高级搜索" Icon="DiskBlackMagnify" EnableToggle="true">
										<Listeners>
											<Toggle Fn="AdvanceSearch" />
										</Listeners>
									</ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Listeners>
                            <Command Handler="Act(command, record,#{FormPanel1}.getForm());" />
                        </Listeners>
                    </ext:GridPanel>
                    <ext:FormPanel ID="FormPanel1" runat="server" Title="新增" Margins="5 5 5 5" Padding="5" Region="East" ButtonAlign="Right" AutoScroll="true">
						<Defaults>
							<ext:Parameter Name="AnchorHorizontal" Value="95%" />
                            <%--<ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />--%>
						</Defaults>
                        <Items>
							
                            <ext:Hidden ID="ID" DataIndex="ID" Text="-1" runat="server">
                            </ext:Hidden>

<%--							<ext:NumberField ID="ClassID" DataIndex="ClassID" runat="server" FieldLabel="类ID" />

							<ext:TextField ID="ClassName" DataIndex="ClassName" runat="server" FieldLabel="类名" />--%>

                            <ext:SelectBox
                                ID="ClassID"
                                runat="server" 
                                DisplayField="ClassName"
                                FieldLabel="所在栏目"
                                ValueField="ID"
                                EmptyText="请选择所在分类...">
                                <Store>
                                    <ext:Store runat="server">
                                        <Reader>
                                            <ext:JsonReader>
                                                <Fields>
                                                    <ext:RecordField Name="ClassName" />
                                                    <ext:RecordField Name="ID" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>            
                                    </ext:Store>    
                                </Store>    
                            </ext:SelectBox>

							<ext:TextField ID="Name" DataIndex="Name" runat="server" FieldLabel="名称" />

							<ext:TextField ID="Specification" DataIndex="Specification" runat="server" FieldLabel="产品规格" Visible="false" />

							<ext:TextField ID="Units" DataIndex="Units" runat="server" FieldLabel="单位" Visible="false" />

							<ext:NumberField ID="Price" DataIndex="Price" runat="server" FieldLabel="单价" Visible="false" />

							<ext:TextField ID="ProduceLocation" DataIndex="ProduceLocation" runat="server" FieldLabel="产地" Visible="false" />

							<%--<ext:TextField ID="FaceImage" DataIndex="FaceImage" runat="server" FieldLabel="图片" />--%>
                            <ext:FileUploadField 
                                ID="FaceImage" 
                                runat="server" 
                                FieldLabel="图片"
                                ButtonText=""
                                Icon="ImageAdd"
                                AnchorHorizontal="95%"
                                />

							<ext:TextField ID="Contact" DataIndex="Contact" runat="server" FieldLabel="联系人" Visible="false" />

							<ext:TextField ID="Tel" DataIndex="Tel" runat="server" FieldLabel="电话" Visible="false" />

							<ext:HtmlEditor ID="Intro" DataIndex="Intro" runat="server" FieldLabel="简介" />

							<ext:DateField ID="AddTime" DataIndex="AddTime" runat="server" FieldLabel="添加时间" />

							<ext:Checkbox ID="Enable" DataIndex="Enable" runat="server" FieldLabel="可用" Visible="false" />

							<ext:Checkbox ID="SetTop" DataIndex="SetTop" runat="server" FieldLabel="是否置顶" />

							<ext:NumberField ID="ClickCount" DataIndex="ClickCount" runat="server" FieldLabel="点击次数" />

							<ext:NumberField ID="OrderIndex" DataIndex="OrderIndex" runat="server" FieldLabel="序号" />

                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="保存">
                                <DirectEvents>
                                    <Click OnEvent="Form_Save" />
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" Text="重置">
                                <DirectEvents>
                                    <Click OnEvent="Form_Reset" />
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" Text="取消">
                                <DirectEvents>
                                    <Click OnEvent="Cancel_Click" />
                                </DirectEvents>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
	<ext:KeyNav runat="server" Target="={document.body}">
        <Enter Handler="server.BindData();" />
    </ext:KeyNav>
    <ext:DropTarget ID="DropTarget1" runat="server" Target="={GridPanel1.getView().mainBody}"
        Group="DDGroup">
        <NotifyDrop Fn="notifyDrop" />
    </ext:DropTarget>
    </form>
</body>
</html>
