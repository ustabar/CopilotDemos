import requests
import pandas as pd
import msoffcrypto 
import sys
import numpy as np

# Create a file handle to the encrypted file
## with open("C:\\app\\My_PFE_Schedule_LAST.xlsx", "rb") as file:
    # Create a decryptor with msoffcrypto
##     file_dec = msoffcrypto.OfficeFile(file)

    # Set the password for the decryptor
## file_dec.load_key(password="***")

    # Create a new decrypted file
##     with open("decrypted_file.xlsx", "wb") as decrypted_file:
        # Decrypt the file
##         file_dec.decrypt(decrypted_file)

print("--> File is beeing loaded")

# Read the Excel file, skipping the first 4 rows and parsing the first column as dates
## df = pd.read_excel("decrypted_file.xlsx", sheet_name='EkoVal', skiprows=4, parse_dates=[0])
df = pd.read_excel("decrypted_file.xlsx", sheet_name='EkoVal', skiprows=3)

print("--> Here are the columns")

# Print the DataFrame
print(df)
print(df.columns)

df['year'] = pd.to_datetime(df.iloc[:, 0], errors='coerce').dt.year
df['month'] = pd.to_datetime(df.iloc[:, 0], errors='coerce').dt.month

# Group by year and month, and calculate the sum of the second column
df_grouped = df.select_dtypes(include=[np.number]).groupby(['year', 'month']).mean()
## print(df_grouped.dtypes)
column_names = df_grouped.columns
print(column_names)
print(df_grouped.iloc[:, 0].name)
print(df_grouped.iloc[:, 0].sum())
print(df_grouped)
sys.exit()


# Print the result
print(df_sumx)

sys.exit()

# Try to convert the first column to datetime, and ignore errors
df.iloc[:, 0] = pd.to_datetime(df.iloc[:, 0], errors='coerce')

print("--> Here are the dates")
print(df['year'])

# Filter rows where year is 2022
df_2024 = df[df['year'] == 2024]

# Filter rows where month is January
df_january = df[df['month'] == 1]

print("--> Here are the dates for 2024 and January 2024")

# Print the filtered DataFrames
print(df_2024)
print(df_january)

print("--> program is done. Exiting...")

# Filter rows where year is 2024 and month is January
df_2024_january = df[(df['year'] == 2024) & (df['month'] == 1)]

print(df_2024_january.iloc[:, 1])

# Calculate the sum of the 'value' column
sum_value = df_2024_january.iloc[:, 1].sum()

# Create a single row DataFrame with the sum
df_sum = pd.DataFrame({'Sum': [sum_value]})

# Print the sum
print(sum_value)

sys.exit()

# Load the Excel file
xls = pd.ExcelFile('decrypted_file.xlsx')

# Get the sheet names
sheet_names = xls.sheet_names

# Print the sheet names
print(sheet_names)