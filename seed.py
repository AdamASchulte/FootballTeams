import random
import sqlite3
import uuid

print("Connecting to db...")
con = sqlite3.connect("./FootballTeams.db")
print("Connected!")
cur = con.cursor()

###Inserting into db###
playerid = str(uuid.uuid4())
first_names = ["Alice", "Bob", "Charlie", "David", "Emma", "Frank", "Grace", "Henry", "Ivy", "Jack",
               "Katherine", "Leo", "Mia", "Nathan", "Olivia", "Paul", "Quinn", "Ryan", "Sophia", "Tyler",
               "Ursula", "Victor", "Wendy", "Xander", "Yvonne"]
last_names = ["Anderson", "Brown", "Clark", "Davis", "Edwards", "Fisher", "Garcia", "Hill", "Irwin", "Johnson",
              "Keller", "Lee", "Miller", "Nguyen", "O'Connor", "Perez", "Quinn", "Roberts", "Smith", "Taylor",
              "Upton", "Vasquez", "Williams", "Xiao", "Young"]
positions = ["Quarterback", "Linebacker", "Wide Receiver", "Runningback", "Kicker"]

for x in range(25):
    playerid = str(uuid.uuid4())
    name = random.choice(first_names) + " " + random.choice(last_names)
    team_id = "A94C19D6-B630-4A98-8C1B-8296786268C3"
    jersey_number = random.randint(0,100)
    salary = random.randint(20000, 250000)
    position = random.choice(positions)
    cur.execute("""INSERT INTO Players VALUES (?, ?, ?, ?, ?, ?)""", (playerid, name, team_id, jersey_number, salary, position))

con.commit()

###Querying db###
results = [a for a in cur.execute("SELECT * FROM Players")]
for res in results:
    print(f"{res}\n")

con.close()