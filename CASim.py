class Cell:
    def __init__ (self,x,y,no):
        self.x=x
        self.y = y
        self.id = no
        self.Connections = [None for i in range (8)]
        self.neighs = [None for i in range (8)]

    def SetConn(self,i, conn, cell):
        self.Connections[i] = conn
        self.neighs[i] = cell

class Neigh:
    def __init__ (self,C0,C1):
            self.C0 = C0
            self.C1 = C1
            self.direction = -1

    def SetDependency(self,direction):
        self.direction = direction

'''Directions as follows:
   704
   3S1
   625
'''
Dirs= { 0 : (-1,0), 1 : (0, 1), 2 : (1,0), 3: (0,-1) ,
            4: (-1,1), 5: (1,1), 6 : (1,-1), 7: (-1,-1) }

X = 20
Y = 20

import random
import io


#create cells
Cells = [ Cell(i,j, (i*X) + j) for i in range (X) for j in range (Y) ]

Field = []

#Set up the field
start = 0
while start < X*Y:
    Field.append(Cells[start:start+X])
    start += X

#Create connections
for i in range (X):
    for j in range (Y):
        for k in [0,1,4,5]:
            ncell = Field[(i+Dirs[k][0])%Y][(j+Dirs[k][1])%X]
            conn = Neigh(Field[i][j], ncell)
            Field[i][j].SetConn(k,conn, ncell)
            ncell.SetConn((k+2),conn, Field[i][j])



#for i in Field:
#    print ([j.id for j in (i)])

#for k in range(8):
#   print (k, Field[2][4].neighs[k].id)
avgdeps = [0 for i in range (X*Y)]
avgbins = [0 for i in range (9)]
runs = 10000

for k in range (runs):
    for i in range (X*Y):
        z = random.randint(i,X*Y-1)
        Cells[i],Cells[z] = Cells[z], Cells[i]


    Dependencies = []

    for c in Cells:
        deps = 0
        for x in range (8):
            if c.Connections[x].direction > -1:
                deps+=1
        Dependencies.append(deps)
        for x in range (8):
            c.Connections[x].direction = 1

    for i in range (X*Y):
        avgdeps[i] += Dependencies[i]

    for c in Cells:
        deps = 0
        for x in range(8):
            if c.Connections[x].direction > -1:
                deps += 1
            c.Connections[x].direction = -1
        avgbins[deps]+=1
        

with open("data.csv", 'w') as file:
    for i in range (X*Y):
        file.write( str(i) + " , " + str(avgdeps[i]/runs)+ "\n")

with open("data2.csv", 'w') as file:
    for i in range(9):
        file.write (str(i) + " ," + str(avgbins[i]/runs) + "\n")
