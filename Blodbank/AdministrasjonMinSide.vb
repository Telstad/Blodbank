Imports MySql.Data.MySqlClient
Public Class AdministrasjonMinSide
    Private Sub AdministrasjonMinSide_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")


        Try
            tilkobling.Open()
            MsgBox("Alt gikk greit med å koble til databasen")
            'Lager sentrale objekter

            Dim sql As New MySqlCommand("Select blodtype, type, COUNT(*) antall FROM Blod_lab GROUP BY blodtype, type", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            da.SelectCommand = sql
            da.Fill(interntabell)
            'En tabell har mange rader. DataRow-objektet kan lagre 1 rad om gangen
            Dim rad As DataRow
            Dim blodtype, type As String
            Dim antall As Integer 'hjelpevariabler

            'Fyller listeboksen med ønsket informasjon
            For Each rad In interntabell.Rows
                blodtype = rad("blodtype")
                type = rad("type")
                antall = rad("antall")

                ListBox1.Items.Add(blodtype & ", " & type & ", " & antall)
            Next rad

        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LeggTilHelsepersonell.Show()
    End Sub
End Class