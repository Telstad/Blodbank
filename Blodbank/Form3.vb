Imports MySql.Data.MySqlClient
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'info fra database skjema. flylles ut i listboksen med spørsmål og svar. 
        Dim tilkobling As New MySqlConnection(
       "Server=mysql.stud.iie.ntnu.no;" _
      & "Database=g_oops_04;" _
      & "Uid=g_oops_04;" _
      & "Pwd=W1TzS2W4;")


        'Dim sql As New MySqlCommand("SELECT * FROM spm WHERE person_nr=@f_nr )", tilkobling)
        'Dim da As New MySqlDataAdapter
        'Dim interntabell As New DataTable
        'Dim sql2 As New MySqlCommand("SELECT * FROM svar WHERE person_nr=@f_nr)", tilkobling)
        'Dim da2 As New MySqlDataAdapter
        'Dim interntabell2 As New DataTable
        Dim sql3 As New MySqlCommand("SELECT * FROM skjema WHERE person_nr=@f_nr)", tilkobling)
        Dim da3 As New MySqlDataAdapter
        Dim interntabell3 As New DataTable


        ''sql.Parameters.AddWithValue("@f_nr", f_nr)
        ''sql2.Parameters.AddWithValue("@f_nr", f_nr)
        'sql3.Parameters.AddWithValue("@f_nr", f_nr)

        'sql.ExecuteNonQuery()
        'sql2.ExecuteNonQuery()
        'sql3.ExecuteNonQuery()


    End Sub


End Class