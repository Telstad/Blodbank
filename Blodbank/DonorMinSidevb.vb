Imports MySql.Data.MySqlClient
Public Class DonorMinSidevb

    'her fikk vi litt hjelp av en annen student, men det er noe av koden her som ikke blir brukt, men vi vet ikke hva vi kan ta bort.
    Private Sub DonorMinSidevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = Form1.Label5.Text
        Dim person_nr As String 'setter variablene
        person_nr = Form1.Label6.Text

        MonthCalendar1.MinDate = Now.AddDays(90)
        MonthCalendar1.MaxDate = Now.AddDays(10000)

        Me.MonthCalendar1.CalendarDimensions = New System.Drawing.Size(2, 2)
        Me.MonthCalendar1.MaxSelectionCount = 1

        GroupBox1.Enabled = False

        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")

        Try
            tilkobling.Open()

            'Lager sentrale objekter

            Dim sql As New MySqlCommand("SELECT * FROM Blod_lab WHERE person_id=@person_nr ", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@person_nr", person_nr)
            sql.ExecuteNonQuery()

            'Objektet "da" utfører spørringen og legger resultatet i "interntabell"
            da.SelectCommand = sql
            da.Fill(interntabell)

            'En tabell har mange rader. DataRow-objektet kan lagre 1 rad om gangen
            Dim rad As DataRow
            Dim id, person_id, reg_date, mengde, type As String 'hjelpevariabler

            'Fyller listeboksen med ønsket informasjon
            For Each rad In interntabell.Rows
                id = rad("id")
                person_id = rad("person_id")
                reg_date = rad("reg_date")
                mengde = rad("mengde")
                type = rad("type")

                ListBox1.Items.Add(id & ", " & person_id & ", " & reg_date & ", " & mengde & ", " & type)
            Next rad


        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        End Try



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim d1 As Date = DateTimePicker1.Value.ToShortDateString      
        Dim d2 As DateTime = MonthCalendar1.SelectionStart.ToString("yyyy-MM-dd")
        'Dim result As TimeSpan = d2.Subtract(d1)
        'Dim days As Integer = result.TotalDays
        Dim klokke As String = ComboBox1.SelectedItem

        'sier ifra om du prøver og registrere time på helg.
        If MonthCalendar1.SelectionStart.DayOfWeek = 0 Or MonthCalendar1.SelectionStart.DayOfWeek = 6 Then
            MsgBox("Donasjon av blod er ikke tilgjengelig i helgen (lørdag og søndag)")
        ElseIf ComboBox1.SelectedIndex = -1 Then
            MsgBox("Må velge tidspunkt")
        Else
            MsgBox("Bestilling mottatt")
            Label3.Text = "Valg dato; " & d2 & "  Klokken; " & klokke
            MonthCalendar1.Enabled = False
            ComboBox1.Enabled = False


            'oppkobling mot databasen
            Dim tilkobling As New MySqlConnection(
                "Server=mysql.stud.iie.ntnu.no;" _
               & "Database=g_oops_04;" _
               & "Uid=g_oops_04;" _
               & "Pwd=W1TzS2W4;")

            Try
                tilkobling.Open()
                MsgBox("Du vil få en eMail med når du skal på tappetime.")
                'Lager sentrale objekter

                Dim person_nr, dato As String 'setter variablene
                person_nr = Form1.Label6.Text
                dato = Format(d2, "yyyy-MM-dd") & " " & klokke & ":00"

                'lagrer kontaktinfo om donor opp mot databasen
                Dim sql As New MySqlCommand("INSERT INTO Koo (person_nr, dato) VALUES (@person_nr, @dato)", tilkobling)
                Dim da As New MySqlDataAdapter
                Dim interntabell As New DataTable

                sql.Parameters.AddWithValue("@person_nr", person_nr)
                sql.Parameters.AddWithValue("@dato", dato)

                sql.ExecuteNonQuery()

                tilkobling.Close() ' stenger tilkoblingen til databasen
                'sjekker for feilmelding
            Catch feilmelding As MySqlException
                MsgBox("Feil ved tilkobling til databasen: " &
                feilmelding.Message)
            Finally
                tilkobling.Dispose()
            End Try
            'TODO legge inn tidspunkt for tapping, når han kan tappes neste gang. HENT INFO FRA LISTBOX1. der ligger datoene når blod ble tappet sist. se DonorMinSidevb_Load.
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'TODO legge til funksjonen som skifter dato på timen.

        MonthCalendar1.Enabled = True
        ComboBox1.Enabled = True
        Label3.Text = ""
    End Sub

    'knapp for å gå til skjema for spørsmål og egenerklæring.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Skjema.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub

    'for at brukere ikke kan skrive tekst eller lignende i comboboxen der man velger klokkeslett.
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GroupBox1.Enabled = True
        TextBox3.ReadOnly = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GroupBox1.Enabled = False
        Dim tilkobling As New MySqlConnection(
       "Server=mysql.stud.iie.ntnu.no;" _
      & "Database=g_oops_04;" _
      & "Uid=g_oops_04;" _
      & "Pwd=W1TzS2W4;")
        Try

            tilkobling.Open()

            Dim Nyfornavn = TextBox1.Text
            Dim Nyetternavn = TextBox2.Text
            Dim Nyf_nr = TextBox3.Text
            Dim Nyadresse = TextBox4.Text & " " & TextBox5.Text & " " & TextBox6.Text
            Dim Nytlf = TextBox9.Text
            Dim Nyepost = TextBox10.Text
            Dim Nybrukernavn = TextBox7.Text
            Dim Nypassord = TextBox8.Text
            Dim person_nr = Form1.Label6.Text


            Dim sql As New MySqlCommand("UPDATE BrukerDonor SET fornavn = @Nyfornavn, etternavn = @Nyetternavn, email=@Nyepost, tlf=@Nytlf, f_nr=@Nyf_nr, adresse=@Nyadresse, brukernavn=@Nybrukernavn, passord=@Nypassord, WHERE f_nr = @person_nr )", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@Nyfornavn", Nyfornavn)
            sql.Parameters.AddWithValue("@Nyetternavn", Nyetternavn)
            sql.Parameters.AddWithValue("@Nyf_nr", Nyf_nr)
            sql.Parameters.AddWithValue("@Nyadresse", Nyadresse)
            sql.Parameters.AddWithValue("@Nytlf", Nytlf)
            sql.Parameters.AddWithValue("@Nyepost", Nyepost)
            sql.Parameters.AddWithValue("@Nybrukernavn", Nybrukernavn)
            sql.Parameters.AddWithValue("@Nypassord", Nypassord)
            sql.Parameters.AddWithValue("@person_nr", person_nr)
            sql.ExecuteNonQuery()

            tilkobling.Close() ' stenger tilkoblingen til databasen
            'sjekker for feilmelding
        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
     feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try

    End Sub


End Class