Imports MySql.Data.MySqlClient
Public Class HelsepersonellMinSide
    Private Sub HelsepersonellMinSide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO:
        'Første sjekk, lage bruker. Sende info om bruker til database-donor.
        'Gi ett passord og brukernavn(email) til bruker(password generator?) + Legge til blodtype på database-donor.
        'knapp for og lage bruker ( hente info fra legesjekk og lage bruker i donor

        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")

        Try
            tilkobling.Open()
            MsgBox("Alt gikk greit med å koble til databasen")
            'Lager sentrale objekter

            Dim sql As New MySqlCommand("SELECT * FROM legeSjekk ", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            'Objektet "da" utfører spørringen og legger resultatet i "interntabell"
            da.SelectCommand = sql
            da.Fill(interntabell)

            'En tabell har mange rader. DataRow-objektet kan lagre 1 rad om gangen
            Dim rad As DataRow
            Dim fornavn, etternavn, adresse, tlf, email, f_nr As String 'hjelpevariabler

            'Fyller listeboksen med ønsket informasjon

            For Each rad In interntabell.Rows
                fornavn = rad("fornavn")
                etternavn = rad("etternavn")
                adresse = rad("adresse")
                tlf = rad("tlf")
                email = rad("email")
                f_nr = rad("f_nr")
                ListBox1.Items.Add(fornavn & ", " & etternavn & ", " & adresse & ", " & tlf & ", " & email & ", " & f_nr)
            Next rad


        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        End Try

        Try


            Dim sql2 As New MySqlCommand("SELECT * FROM Koo", tilkobling) 'TODO legge til dato her. order by date eller noe.
            Dim da2 As New MySqlDataAdapter
            Dim interntabell2 As New DataTable

            da2.SelectCommand = sql2
            da2.Fill(interntabell2)

            'En tabell har mange rader. DataRow-objektet kan lagre 1 rad om gangen

            'Har ikke lenger bruk for å være tilkoblet til databasen
            tilkobling.Close()

            Dim rad2 As DataRow
            Dim dato As String 'hjelpevariabler
            Dim person_nr As String

            For Each rad2 In interntabell2.Rows
                person_nr = rad2("person_nr")
                dato = rad2("dato")
                ListBox2.Items.Add(person_nr & ", " & dato)
            Next rad2
        Catch feilmelding As Exception
            MsgBox("Feil ved tilkobling til databasen: " & " (ved feilmeldig andående dato i WHERE clause. så betyr det bare at det ikke er folk som står i kø for og bli tappet) " &
           feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try

        'Form1.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Legesjekk.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RegistreringAvBlodtapping.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        BestillingAvBlod.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("sender ut en email på tlf til folk som ikke er i karantene eller på ventetid, at det ønskes at de kommer på blodtapping.")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("sender ut en meldig til tlf til alle som har O- og ønsker at de kommer på blodtapping så fort som mulig.")
    End Sub
End Class