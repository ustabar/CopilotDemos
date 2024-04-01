import java.util.date;

Data class SampleData {
    private String name;
    private Date dateOfBirth;
    private int age;
    private String address;
    private String phoneNumber;
    private String email;
}

val contacts = listOf(
    SampleData("John Doe", Date(1980, 1, 12), 40, "123 Main St", "123-456-7890", ""),
    SampleData("Jane Doe", Date(1985, 2, 15), 35, "456 Main St", "123-456-7890", ""),
    SampleData("John Smith", Date(1975, 3, 18), 45, "789 Main St", "123-456-7890", ""),
)

// Q: How many contacts are there?
// A: 3

// Q: What is the average age of the contacts?
// A: 40

// Q: what is await and async and how to use it?
// A: await is used to wait for the result of an async function. async is used to define a function that returns a promise.

// SQL query to search contact by name
SELECT * FROM contacts WHERE name = 'John Doe';

// SQL query to update contact by email
UPDATE contacts SET email = 'test@test.com' WHERE name = 'John Doe';

// regex to validate email
private val1 = Pattern.compile("^[A-Za-z0-9+_.-]+@(.+)$");

// regex to validate phone number
private val2 = Pattern.compile("^[0-9]{3}-[0-9]{3}-[0-9]{4}$");

// regex to validate date of birth in format dd-mm-yyyy
private val3 = Pattern.compile("^(0[1-9]|1[0-2])-(0[1-9]|1[0-9]|2[0-9]|3[0-1])-[0-9]{4}$");

private string sample = "deneme 1 2 3 4 5 6 7 8 9 0";
// replace space in sample with comma and print the result below line
// deneme,1,2,3,4,5,6,7,8,9,0

// select all the code and fix it in chat window
