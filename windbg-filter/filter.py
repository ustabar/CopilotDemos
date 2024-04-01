# i would like to filter out !name2ee command output containes none 
# empty JITTED Code Address and previous 5 lines using a python script
#
# .shell -ci "!name2ee * System.Threading.Thread.Abort" python C:\DbgHelpers\Scripts\filter.py

# .shell -ci "!name2ee * " python C:\Scripts\filter.py
            
import sys

output = sys.stdin.read()
lines = output.split('\n')

for i in range(len(lines)):
    if 'JITTED Code Address:' in lines[i] and lines[i].split('JITTED Code Address:')[1].strip() != '(null)':
        for j in range(max(0, i - 5), i + 1):
            print(lines[j])