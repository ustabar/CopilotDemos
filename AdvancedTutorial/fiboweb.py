from flask import Flask, request

app = Flask(__name__)

@app.route('/fibonacci', methods=['POST'])
def fibonacci():
    n = int(request.form['number'])
    a, b = 0, 1
    result = [a]
    for i in range(1, n):
        a, b = b, a + b
        result.append(a)        
    return f'The first {n} Fibonacci numbers are: {", ".join(map(str, result))}'

@app.route('/')
def home():
    return ''' 
        <html>
        <head>
            <style>
                body {
                    background-color: black;
                    color: lime;
                    font-family: 'Courier New', Courier, monospace;
                }
                form {
                    margin: auto;
                    width: 50%;
                    padding: 10px;
                }
                button {
                    background-color: lime;
                    color: black;
                    border: none;
                    padding: 5px 10px;
                    text-align: center;
                    text-decoration: none;
                    display: inline-block;
                    font-size: 16px;
                    margin: 4px 2px;
                    cursor: pointer;
                }
            </style>
        </head>
        <body>
            <form action="/fibonacci" method="post">
                <label for="number">How many numbers?</label><br>
                <input type="number" id="number" name="number" min="1" required><br>
                <button type="submit" onclick="myFunction()">Submit</button>
            </form>
            <script>
                function myFunction() {
                    alert("Fibonacci sequence is being generated!");
                }
            </script>
        </body>
        </html>
    '''
if __name__ == '__main__':
    app.run(debug=True)