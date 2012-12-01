<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.system.Message.List" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Message列表</title>
	<script type="text/javascript" src="../../../data/script/management.js"></script>
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

					<ext:TextField ID="s_UserName" DataIndex="UserName" runat="server" EmptyText="姓名" Margins="0 5 0 0" />

					<ext:TextField ID="s_Email" DataIndex="Email" runat="server" EmptyText="邮箱" Margins="0 5 0 0" />

					<ext:TextField ID="s_Tel" DataIndex="Tel" runat="server" EmptyText="电话" Margins="0 5 0 0" />

					<ext:TextField ID="s_Title" DataIndex="Title" runat="server" EmptyText="标题" Margins="0 5 0 0" />

					<ext:TextField ID="s_Chat" DataIndex="Chat" runat="server" EmptyText="即时消息" Margins="0 5 0 0" />

					<ext:TextField ID="s_Content" DataIndex="Content" runat="server" EmptyText="内容" Margins="0 5 0 0" />

                    
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
                    <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" Title="列表管理" AutoExpandColumn="Title"
                        Margins="5 5 5 5">
                        <Store>
                            <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
                                <Reader>
                                    <ext:JsonReader IDProperty="ID">
                                        <Fields>
											<ext:RecordField Name="ID" Type="Int" />
											<ext:RecordField Name="MessageTime" Type="Date" />
											<ext:RecordField Name="UserName" Type="String" />
											<ext:RecordField Name="Email" Type="String" />
											<ext:RecordField Name="Tel" Type="String" />
											<ext:RecordField Name="Title" Type="String" />
											<ext:RecordField Name="Chat" Type="String" />
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
                                <ext:Column Header="标题" DataIndex="Title"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
								<ext:DateColumn Header="留言时间" DataIndex="MessageTime"><Editor><ext:DateField runat="server" /></Editor></ext:DateColumn>
								<ext:Column Header="姓名" DataIndex="UserName"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
								<ext:Column Header="邮箱" DataIndex="Email"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
								<ext:Column Header="电话" DataIndex="Tel"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
								<ext:Column Header="即时消息" DataIndex="Chat"><Editor><ext:TextField runat="server" /></Editor></ext:Column>
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
							<ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
						</Defaults>
                        <Items>
							
                            <ext:Hidden ID="ID" DataIndex="ID" Text="-1" runat="server">
                            </ext:Hidden>

							<ext:DateField ID="MessageTime" DataIndex="MessageTime" runat="server" FieldLabel="留言时间" />

							<ext:TextField ID="UserName" DataIndex="UserName" runat="server" FieldLabel="姓名" />

							<ext:TextField ID="Email" DataIndex="Email" runat="server" FieldLabel="邮箱" />

							<ext:TextField ID="Tel" DataIndex="Tel" runat="server" FieldLabel="电话" />

							<ext:TextField ID="Title" DataIndex="Title" runat="server" FieldLabel="标题" />

							<ext:TextField ID="Chat" DataIndex="Chat" runat="server" FieldLabel="即时消息" />

							<ext:HtmlEditor ID="Content" DataIndex="Content" runat="server" FieldLabel="内容" />

                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="保存">
                                <Listeners>
                                    <Click Fn="SaveData" />
                                </Listeners>
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
    </form>
</body>
</html>