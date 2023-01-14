# CryptographyCourseProject

A simple console application implementation of a combined Transposition-Substitution-Transposition cypher. Course task for the Cryptography course (5th semester).

## Used cryptographic methods
- Columnar transposition - The message is written out in rows of a fixed length, and then read out again column by column, and the columns are chosen in some scrambled order. Both the width of the rows and the permutation of the columns are usually defined by a keyword. For example, the keyword ZEBRAS is of length 6 (so the rows are of length 6), and the permutation is defined by the alphabetical order of the letters in the keyword. In this case, the order would be "6 3 2 4 1 5".
- Direct substitution - Each character of the plain text is substituted with a specified number (Randomly generated 2-digit number in this case)

## Functionality
- Encryption - `Plain text -> Columnar transposition -> Direct substitution -> Columnar transposition -> Cryptogram`
- Decryption - `Cryptogram -> Columnar transposition -> Direct substitution -> Columnar transposition -> Plain text`

The user specifies the keywords used for the Columnar transposition (Works best when keyword length is a divisor of the plain text length!).
The application shows the intermediate results of each method in both directions - Encryption/Decryption

## Supported characters
`[A-Z], [a-z], ' ', ',', ';', ':', '!', '?', '-', '.'`
