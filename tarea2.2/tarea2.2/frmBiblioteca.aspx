<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBiblioteca.aspx.cs" Inherits="tarea2._2.frmBiblioteca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Biblioteca</title>
     <link rel="stylesheet" href="css/estilos.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="datos">
                ISBN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <input id="isbn" type="text" runat="server"/><br />
                <br />
                Título<br />
                <input id="titulo" type="text" runat="server"/><br />
                <br />
                Número de edición<br />
                <input id="num_edicion" type="text" runat="server"/><br />
                <br />
                Año de publicación<br />
                <input id="publicacion" type="text" runat="server"/></div>

            
            <br />
            <div class="datos">
                Autores<br />
                <input id="autores" type="text" runat="server"/><br />
                <br />
                País de publicación<br />
                <input id="pais" type="text" runat="server"/><br />
                <br />
                Sinopsis<br />
                <input id="sinopsis" type="text" runat="server"/><br />
                <br />
                Carrera<br />
                <input id="carrera" type="text" runat="server"/><br />
                <br />
                Materia<br />
                <input id="materia" type="text" runat="server"/></div>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
            <br />
        </div>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
       
        <asp:BoundField DataField="isbn" HeaderText="ISBN" />
        <asp:BoundField DataField="titulo" HeaderText="Titulo" />
         <asp:BoundField DataField="numero_de_edicion" HeaderText="Número de edición" />
        <asp:BoundField DataField="ano_de_publicacion" HeaderText="Año de publicación" />
         <asp:BoundField DataField="nombre_de_autores" HeaderText="Autores" />
        <asp:BoundField DataField="pais_de_publicacion" HeaderText="Pais de publicacion" />
         <asp:BoundField DataField="sinopsis" HeaderText="Sinopsis" />
        <asp:BoundField DataField="carrera" HeaderText="Carrera" />
         <asp:BoundField DataField="materia" HeaderText="Materia" />
        
    </Columns>
</asp:GridView>
    </form>

    

</body>
</html>
