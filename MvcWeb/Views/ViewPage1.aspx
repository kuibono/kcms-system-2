<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Voodoo.Basement.Book>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ViewPage1</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                ClassID
            </th>
            <th>
                ClassName
            </th>
            <th>
                ZtID
            </th>
            <th>
                ZtName
            </th>
            <th>
                Title
            </th>
            <th>
                Author
            </th>
            <th>
                Intro
            </th>
            <th>
                Length
            </th>
            <th>
                ReplyCount
            </th>
            <th>
                ClickCount
            </th>
            <th>
                Addtime
            </th>
            <th>
                Status
            </th>
            <th>
                IsVip
            </th>
            <th>
                FaceImage
            </th>
            <th>
                SaveCount
            </th>
            <th>
                Enable
            </th>
            <th>
                IsFirstPost
            </th>
            <th>
                LastChapterID
            </th>
            <th>
                LastChapterTitle
            </th>
            <th>
                UpdateTime
            </th>
            <th>
                LastVipChapterID
            </th>
            <th>
                LastVipChapterTitle
            </th>
            <th>
                VipUpdateTime
            </th>
            <th>
                CorpusID
            </th>
            <th>
                CorpusTitle
            </th>
            <th>
                TjCount
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.ID })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.ID })%>
            </td>
            <td>
                <%= Html.Encode(item.ID) %>
            </td>
            <td>
                <%= Html.Encode(item.ClassID) %>
            </td>
            <td>
                <%= Html.Encode(item.ClassName) %>
            </td>
            <td>
                <%= Html.Encode(item.ZtID) %>
            </td>
            <td>
                <%= Html.Encode(item.ZtName) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.Author) %>
            </td>
            <td>
                <%= Html.Encode(item.Intro) %>
            </td>
            <td>
                <%= Html.Encode(item.Length) %>
            </td>
            <td>
                <%= Html.Encode(item.ReplyCount) %>
            </td>
            <td>
                <%= Html.Encode(item.ClickCount) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Addtime)) %>
            </td>
            <td>
                <%= Html.Encode(item.Status) %>
            </td>
            <td>
                <%= Html.Encode(item.IsVip) %>
            </td>
            <td>
                <%= Html.Encode(item.FaceImage) %>
            </td>
            <td>
                <%= Html.Encode(item.SaveCount) %>
            </td>
            <td>
                <%= Html.Encode(item.Enable) %>
            </td>
            <td>
                <%= Html.Encode(item.IsFirstPost) %>
            </td>
            <td>
                <%= Html.Encode(item.LastChapterID) %>
            </td>
            <td>
                <%= Html.Encode(item.LastChapterTitle) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.UpdateTime)) %>
            </td>
            <td>
                <%= Html.Encode(item.LastVipChapterID) %>
            </td>
            <td>
                <%= Html.Encode(item.LastVipChapterTitle) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.VipUpdateTime)) %>
            </td>
            <td>
                <%= Html.Encode(item.CorpusID) %>
            </td>
            <td>
                <%= Html.Encode(item.CorpusTitle) %>
            </td>
            <td>
                <%= Html.Encode(item.TjCount) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</body>
</html>

