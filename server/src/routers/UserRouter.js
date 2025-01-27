const express = require("express")
const router = express.Router()


const auth = require("../middleware/auth")
const {
    loginUser,
    logoutUser,
    registerUser,
    getUser,
    getUserByUsername,
    addArtifact,
    addAchievement
} = require("../controllers/UserController")


router.post("/login", loginUser)
router.post("/register", registerUser)
router.get("/logout", auth, logoutUser)
router.get("/user", auth, getUser)
router.get("/user/:username", getUserByUsername)
router.post("/add-artifact", auth, addArtifact)
router.post("/add-achievement", auth, addAchievement)




module.exports = router