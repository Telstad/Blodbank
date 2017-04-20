Imports MySql.Data.MySqlClient
Public Class RegistreringAvBlodtapping
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'oppkobling mot databasen
        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")

        Dim fulltapp, blodplater, blodceller, plasma As Integer
        Dim mengde, person_id, blodtype, type1, type2, type3, antall As String 'setter variablene
        mengde = 450
        person_id = Label5.Text
        blodtype = Label2.Text 'sql for og finne blodtype til person.
        type1 = "blodceller"
        type2 = "blodplater"
        type3 = "plasma"
        antall = 1
        Label6.Text = Form1.Label5.Text

        'Deler blodet inn i 3 deler.
        If CheckBox1.Checked = True Then
            CheckBox2.Visible = False
            CheckBox3.Visible = False
            CheckBox4.Visible = False

            fulltapp = mengde
            blodceller = fulltapp * 0.445
            blodplater = fulltapp * 0.01
            plasma = fulltapp * 0.545

            Try
                tilkobling.Open()

                'Lager sentrale objekter

                'lagrer kontaktinfo om donor opp mot databasen
                Dim sql As New MySqlCommand("INSERT INTO Blod_lab (mengde, person_id, blodtype, type, antall) VALUES (@mengde, @person_id, @blodtype, @type, @antall)", tilkobling)
                Dim da As New MySqlDataAdapter
                Dim interntabell As New DataTable
                Dim sql2 As New MySqlCommand("INSERT INTO Blod_lab (mengde, person_id, blodtype, type, antall) VALUES (@mengde, @person_id, @blodtype, @type, @antall)", tilkobling)
                Dim da2 As New MySqlDataAdapter
                Dim interntabell2 As New DataTable
                Dim sql3 As New MySqlCommand("INSERT INTO Blod_lab (mengde, person_id, blodtype, type, antall) VALUES (@mengde, @person_id, @blodtype, @type, @antall)", tilkobling)
                Dim da3 As New MySqlDataAdapter
                Dim interntabell3 As New DataTable

                sql.Parameters.AddWithValue("@mengde", blodceller)
                sql.Parameters.AddWithValue("@person_id", person_id)
                sql.Parameters.AddWithValue("@blodtype", blodtype)
                sql.Parameters.AddWithValue("@type", type1)
                sql.Parameters.AddWithValue("@antall", antall)

                sql2.Parameters.AddWithValue("@mengde", blodplater)
                sql2.Parameters.AddWithValue("@person_id", person_id)
                sql2.Parameters.AddWithValue("@blodtype", blodtype)
                sql2.Parameters.AddWithValue("@type", type2)
                sql2.Parameters.AddWithValue("@antall", antall)

                sql3.Parameters.AddWithValue("@mengde", plasma)
                sql3.Parameters.AddWithValue("@person_id", person_id)
                sql3.Parameters.AddWithValue("@blodtype", blodtype)
                sql3.Parameters.AddWithValue("@type", type3)
                sql3.Parameters.AddWithValue("@antall", antall)

                sql.ExecuteNonQuery()
                sql2.ExecuteNonQuery()
                sql3.ExecuteNonQuery()

                tilkobling.Close() ' stenger tilkoblingen til databasen
                'sjekker for feilmelding
            Catch feilmelding As MySqlException
                MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
            Finally
                MsgBox("registreing fullført")
                Me.Close()
                tilkobling.Dispose()
            End Try


            'detter er hvis dcet bare tappes røde blodceller
        ElseIf CheckBox2.Checked = True Then
            CheckBox1.Visible = False
            CheckBox3.Visible = False
            CheckBox4.Visible = False
            mengde = 200
            blodceller = mengde
            Try
                tilkobling.Open()
                MsgBox("Tilkobling godkjent.")
                'Lager sentrale objekter

                'lagrer kontaktinfo om donor opp mot databasen
                Dim sql As New MySqlCommand("INSERT INTO Blod_lab (mengde, person_id, blodtype, type) VALUES (@mengde, @person_id, @blodtype, @type)", tilkobling)
                Dim da As New MySqlDataAdapter
                Dim interntabell As New DataTable

                sql.Parameters.AddWithValue("@mengde", mengde)
                sql.Parameters.AddWithValue("@person_id", person_id)
                sql.Parameters.AddWithValue("@blodtype", blodtype)
                sql.Parameters.AddWithValue("@type", type1)
                sql.ExecuteNonQuery()

                tilkobling.Close() ' stenger tilkoblingen til databasen
                'sjekker for feilmelding
            Catch feilmelding As MySqlException
                MsgBox("Feil ved tilkobling til databasen: " &
             feilmelding.Message)
            Finally
                tilkobling.Dispose()
            End Try

            'dette er hvis de bare tapper blodplater
        ElseIf CheckBox3.Checked = True Then
            CheckBox2.Visible = False
            CheckBox1.Visible = False
            CheckBox4.Visible = False
            mengde = 4
            blodplater = mengde

            Try
                tilkobling.Open()
                MsgBox("Tilkobling godkjent.")
                'Lager sentrale objekter

                'lagrer kontaktinfo om donor opp mot databasen
                Dim sql As New MySqlCommand("INSERT INTO Blod_lab (mengde, person_id, blodtype, type) VALUES (@mengde, @person_id, @blodtype, @type)", tilkobling)
                Dim da As New MySqlDataAdapter
                Dim interntabell As New DataTable

                sql.Parameters.AddWithValue("@mengde", mengde)
                sql.Parameters.AddWithValue("@person_id", person_id)
                sql.Parameters.AddWithValue("@blodtype", blodtype)
                sql.Parameters.AddWithValue("@type", type2)
                sql.ExecuteNonQuery()

                tilkobling.Close() ' stenger tilkoblingen til databasen
                'sjekker for feilmelding
            Catch feilmelding As MySqlException
                MsgBox("Feil ved tilkobling til databasen: " &
             feilmelding.Message)
            Finally
                tilkobling.Dispose()
            End Try

            'dette er hvis de bare tapper Plasma
        ElseIf CheckBox4.Checked = True Then
            CheckBox2.Visible = False
            CheckBox3.Visible = False
            CheckBox1.Visible = False
            mengde = 245
            plasma = mengde

            Try
                tilkobling.Open()
                MsgBox("Tilkobling godkjent.")
                'Lager sentrale objekter

                'lagrer kontaktinfo om donor opp mot databasen
                Dim sql As New MySqlCommand("INSERT INTO Blod_lab (mengde, person_id, blodtype, type) VALUES (@mengde, @person_id, @blodtype, @type)", tilkobling)
                Dim da As New MySqlDataAdapter
                Dim interntabell As New DataTable

                sql.Parameters.AddWithValue("@mengde", mengde)
                sql.Parameters.AddWithValue("@person_id", person_id)
                sql.Parameters.AddWithValue("@blodtype", blodtype)
                sql.Parameters.AddWithValue("@type", type3)
                sql.ExecuteNonQuery()

                tilkobling.Close() ' stenger tilkoblingen til databasen
                'sjekker for feilmelding
            Catch feilmelding As MySqlException
                MsgBox("Feil ved tilkobling til databasen: " &
             feilmelding.Message)
            Finally
                tilkobling.Dispose()
            End Try

        ElseIf CheckBox1.Checked And CheckBox2.Checked And CheckBox3.Checked And CheckBox4.Checked = False Then
            MsgBox("Du må krysse av en box")
            'TODO må finne en måte og gjøre sån at kun en checkbox kan bli checked. kanskje checkbox.hide?
        End If
        Try
            tilkobling.Open()
            Dim sql As New MySqlCommand("DELETE FROM Koo WHERE person_nr = @person_id", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@person_id", person_id)
            sql.ExecuteNonQuery()

        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
         feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        'TODO må registrere brukeren i ett register hvor man kan se karantenetid osv. 
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label5.Text = TextBox1.Text
        Dim person_id = Label5.Text
        Dim blodtype = " "

        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")

        Try
            tilkobling.Open()
            MsgBox("Tilkobling godkjent.")
            'Lager sentrale objekter

            'lagrer kontaktinfo om donor opp mot databasen
            Dim sql As New MySqlCommand("SELECT blodtype from BrukerDonor where f_nr = @person_id", tilkobling)
            sql.Parameters.AddWithValue("@person_id", person_id)

            'Angir variabel for leser. Leser av det gitte resultatet for spørringen.
            Dim leser = sql.ExecuteReader()
            While leser.Read()
                blodtype &= leser("blodtype") & " "
            End While
            Label2.Text = blodtype

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

