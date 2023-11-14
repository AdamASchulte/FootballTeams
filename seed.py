import sqlite3
import uuid

print("Connecting to db...")
con = sqlite3.connect("./FootballTeams.db")
print("Connected!")
cur = con.cursor()
print("Selecting names...")
table_list = [a for a in cur.execute("SELECT name FROM sqlite_master WHERE type = 'table'")]
print(table_list)

guid = str(uuid.uuid4())
city = "Baton Rouge"
state = "Louisiana"

guid2 = str(uuid.uuid4())
city2 = "Branson"
state2 = "Missouri"

#cur.execute("""
#    INSERT INTO Locations VALUES
#            (?, ?, ?)
#""", (guid2, city2, state2))

#con.commit()

res = [a for a in cur.execute("SELECT * FROM Locations")]
print(res)

con.close()