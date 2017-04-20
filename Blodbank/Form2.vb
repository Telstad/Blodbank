Imports MySql.Data.MySqlClient
Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'oppkobling mot databasen
        Dim tilkobling As New MySqlConnection(
            "Server=mysql.stud.iie.ntnu.no;" _
           & "Database=g_oops_04;" _
           & "Uid=g_oops_04;" _
           & "Pwd=W1TzS2W4;")

        Try
            tilkobling.Open()
            MsgBox("Du vil få en eMail med når du skal på legetime.")
            'Lager sentrale objekter

            Dim fornavn, etternavn, email, tlf, f_nr, adresse As String 'setter variablene
            fornavn = TextBox1.Text
            etternavn = TextBox2.Text
            email = TextBox3.Text
            tlf = TextBox4.Text
            f_nr = TextBox5.Text
            adresse = TextBox6.Text

            'lagrer kontaktinfo om donor opp mot databasen
            Dim sql As New MySqlCommand("INSERT INTO legeSjekk (fornavn, etternavn, email, tlf, f_nr, adresse) VALUES (@fornavn, @etternavn, @email, @tlf, @f_nr, @adresse)", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@fornavn", fornavn)
            sql.Parameters.AddWithValue("@etternavn", etternavn)
            sql.Parameters.AddWithValue("@email", email)
            sql.Parameters.AddWithValue("@tlf", tlf)
            sql.Parameters.AddWithValue("@f_nr", f_nr)
            sql.Parameters.AddWithValue("@adresse", adresse)
            sql.ExecuteNonQuery()

            tilkobling.Close() ' stenger tilkoblingen til databasen
            'sjekker for feilmelding
        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try

        Me.Close() ' når brukeren har fylt ut skjemaet så stenges vinduet.
        Form1.Show()

    End Sub
End Class
