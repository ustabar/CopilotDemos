// Example Go code generating and verifying JWT
func generateJWT(userID string) (string, error) {
    claims := jwt.MapClaims{
        "sub": userID,
        "exp": time.Now().Add(time.Hour * 1).Unix(),
    }
    token := jwt.NewWithClaims(jwt.SigningMethodHS256, claims)
    signedToken, err := token.SignedString([]byte("secret_key"))
    if err != nil {
        return "", err
    }
    return signedToken, nil
}