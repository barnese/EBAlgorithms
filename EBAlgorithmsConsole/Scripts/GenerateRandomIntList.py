import random

# Script settings
minValue = 0
maxValue = 1000
numberOfInts = 10000
outputFileName = "../Data/RandomIntList.txt"

# Generate a comma-separated string of random integers.
intListString = ""

for i in range(0, numberOfInts):
    intListString += str(random.randint(minValue, maxValue))
    if i < numberOfInts - 1:
        intListString += ","

# Write the integers to file.
with open(outputFileName, "w") as file:
    file.write(intListString)
