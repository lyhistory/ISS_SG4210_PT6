<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ListCourse.aspx.cs" Inherits="nus.iss.crs.pl.Admin.ListCourse" %>

<asp:Content ID="Content4" ContentPlaceHolderID="placeholder_MainContent" runat="server">
   <%-- <script type="text/javascript">
        var httpRequest = null;

        function getXMLHttpRequest() {
            if (window.ActiveXObject) {
                try {
                    return new ActiveXObject("Msxml2.XMLHTTP");
                } catch (e) {
                    try {
                        return new ActiveXObject("Microsoft.XMLHTTP");
                    } catch (e1) {
                        return null;
                    }
                }
            } else if (window.XMLHttpRequest) {
                return new XMLHttpRequest();
            } else {
                return null;
            }
        }

        function sendRequest(url, params, callback, method) {
            httpRequest = getXMLHttpRequest();
            var httpMethod = method ? method : 'GET';
            if (httpMethod != 'GET' && httpMethod != 'POST') {
                httpMethod = 'GET';
            }
            var httpParams = (params == null || params == '') ? null : params;
            var httpUrl = url;
            if (httpMethod == 'GET' && httpParams != null) {
                httpUrl = httpUrl + "?" + httpParams;
            }
            httpRequest.open(httpMethod, httpUrl, true);
            httpRequest.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            httpRequest.onreadystatechange = callback;
            httpRequest.send(httpMethod == 'POST' ? httpParams : null);
        }

        function abc(coursecode) {
            alert(coursecode);
            return false;
        }
    </script>--%>
    <blockquote>
        <h2>Executive Education Programmes</h2>
    </blockquote>
        
    <div>
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    </div>
</asp:Content>

