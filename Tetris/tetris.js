// Tetris tahtasını oluştur
const board = Array.from({length: 20}, () => Array(10).fill(0));

// Tetris bloklarını tanımla
const blocks = [
  [[1, 1, 1, 1]], // I
  [[1, 1], [1, 1]], // O
  [[1, 1, 0], [0, 1, 1]], // Z
  [[0, 1, 1], [1, 1]], // S
  [[1, 1, 1], [0, 1, 0]], // T
  [[1, 1, 1], [1, 0, 0]], // L
  [[1, 1, 1], [0, 0, 1]] // J
];

let score = 0;
let currentBlock = getRandomBlock();
let currentX = 5;
let currentY = 0;

// Rastgele bir blok seç
function getRandomBlock() {
  return blocks[Math.floor(Math.random() * blocks.length)];
}

// Bloğu tahtaya yerleştir
function placeBlock(block, x, y) {
  for (let i = 0; i < block.length; i++) {
    for (let j = 0; j < block[i].length; j++) {
      if (block[i][j] === 1) {
        board[y + i][x + j] = 1;
      }
    }
  }
}

// Bloğu döndür
function rotateBlock(block) {
  return block[0].map((val, index) => block.map(row => row[index])).reverse();
}

// Satırları temizle
function clearRows() {
  for (let i = 0; i < board.length; i++) {
    if (board[i].every(cell => cell === 1)) {
      board.splice(i, 1);
      board.unshift(Array(10).fill(0));
      score += 10;
      if (score % 100 === 0) {
        speed *= 0.9; // Hızı %10 düşür
        clearInterval(gameInterval); // Eski intervalı temizle
        gameInterval = setInterval(gameLoop, speed); // Yeni hızla intervalı başlat
      }
    }
  }
}

// Oyunun bitip bitmediğini kontrol et
function isGameOver() {
  return board[0].some(cell => cell === 1);
}

// Hedef konumun geçerli olup olmadığını kontrol et
function isValidMove(block, x, y) {
  for (let i = 0; i < block.length; i++) {
    for (let j = 0; j < block[i].length; j++) {
      if (block[i][j] && (
          // Tahtanın dışına çıkma kontrolü
          x + j < 0 || x + j >= board[0].length || y + i >= board.length ||
          // Diğer blokların üzerine gelme kontrolü
          board[y + i][x + j] !== 0)) {
        return false;
      }
    }
  }
  return true;
}

// Oyun tahtasını çiz
function drawBoard() {
  const boardElement = document.getElementById('board');
  boardElement.innerHTML = '';
  for (let y = 0; y < board.length; y++) {
    for (let x = 0; x < board[y].length; x++) {
      const cell = document.createElement('div');
      cell.classList.add('cell');
      cell.style.top = `${y * 20}px`;
      cell.style.left = `${x * 20}px`;
      if (y >= currentY && y < currentY + currentBlock.length && x >= currentX && x < currentX + currentBlock[0].length && currentBlock[y - currentY][x - currentX] === 1) {
        cell.style.backgroundColor = 'black';
      } else {
        cell.style.backgroundColor = board[y][x] ? 'black' : 'white';
      }
      boardElement.appendChild(cell);
    }
  }
}

// Oyun döngüsü
function gameLoop() {
  if (isValidMove(currentBlock, currentX, currentY + 1)) {
    currentY++;
  } else {
    placeBlock(currentBlock, currentX, currentY);
    currentBlock = getRandomBlock();
    currentX = 5;
    currentY = 0;
    if (!isValidMove(currentBlock, currentX, currentY)) {
      clearInterval(gameInterval);
      console.log('Game over. Your score is:', score);
    }
  }
  clearRows();
  drawBoard();
}

// Kullanıcı girişini işle
window.addEventListener('keydown', (e) => {
  if (e.key === 'ArrowLeft' && isValidMove(currentBlock, currentX - 1, currentY)) {
    currentX--;
  } else if (e.key === 'ArrowRight' && isValidMove(currentBlock, currentX + 1, currentY)) {
    currentX++;
  } else if (e.key === 'ArrowUp') {
    const rotatedBlock = rotateBlock(currentBlock);
    if (isValidMove(rotatedBlock, currentX, currentY)) {
      currentBlock = rotatedBlock;
    }
  } else   if (event.code === 'Space') {
    // Move the block down until it hits the bottom or another block
    while (isValidMove(currentBlock, currentX, currentY + 1)) {
      currentY++;
    }
    // Place the block
    placeBlock(currentBlock, currentX, currentY);
    // Get a new block
    currentBlock = getRandomBlock();
    currentX = 5;
    currentY = 0;
    // Check if the game is over
    if (!isValidMove(currentBlock, currentX, currentY)) {
      clearInterval(gameInterval);
      console.log('Game over. Your score is:', score);
    }
    // Clear rows and draw the board
    clearRows();
    drawBoard();
  }
});

// Oyunu başlat
drawBoard();
const gameInterval = setInterval(gameLoop, 1000);