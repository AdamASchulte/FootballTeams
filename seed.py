import sqlite3
import uuid

print("Connecting to db...")
con = sqlite3.connect("./FootballTeams.db")
print("Connected!")
cur = con.cursor()

###Inserting into db###
#guid = str(uuid.uuid4())
#city = "Baton Rouge"
#state = "Louisiana"

#cur.execute("""
#    INSERT INTO Locations VALUES
#            (?, ?, ?)
#""", (guid, city, state))

#con.commit()

###Querying db###
res = [a for a in cur.execute("SELECT * FROM Locations")]
print(res)

con.close()