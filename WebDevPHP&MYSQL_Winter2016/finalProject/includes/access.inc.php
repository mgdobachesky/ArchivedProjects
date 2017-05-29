<?php

function userIsLoggedIn()
{
    if (isset($_POST['action']) and $_POST['action'] == 'login')
    {
        if (!isset($_POST['email']) or $_POST['email'] == '' or !isset($_POST['password']) or $_POST['password'] == '')
        {
            $GLOBALS['loginError'] = 'Please fill in both fields';
            return FALSE;
        }
        
        $password = md5($_POST['password'] . 'homework');
        
        if (databaseContainsStudent($_POST['email'], $password))
        {
            session_start();
            $_SESSION['loggedIn'] = TRUE;
            $_SESSION['email'] = $_POST['email'];
            $_SESSION['password'] = $password;
            return TRUE;
        }
        else
        {
            session_start();
            unset($_SESSION['loggedIn']);
            unset($_SESSION['email']);
            unset($_SESSION['password']);
            $GLOBALS['loginError'] = 'The specified email address or password was incorrect.';
            return FALSE;
        }
    }
    
    if (isset($_POST['action']) and $_POST['action'] == 'logout')
    {
        session_start();
        unset($_SESSION['loggedIn']);
        unset($_SESSION['email']);
        unset($_SESSION['password']);
        header('Location: ' . $_POST['goto']);
        exit();
    }
    
    session_start();
    if (isset($_SESSION['loggedIn']))
    {
        return databaseContainsStudent($_SESSION['email'], $_SESSION['password']);
    }
}

function databaseContainsStudent($email, $password)
{
    include 'db.inc.php';
    
    try
    {
        $sql = 'SELECT COUNT(*) FROM student
        WHERE email = :email AND password = :password';
        $s = $pdo->prepare($sql);
        $s->bindValue(':email', $email);
        $s->bindValue(':password', $password);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error searching for student.';
        include 'error.html.php';
        exit();
    }
    
    $row = $s->fetch();
    
    if ($row[0] > 0)
    {
        return TRUE;
    }
    else
    {
        return FALSE;
    }
}

function userHasRole($role)
{
    include 'db.inc.php';
    
    try
    {
        $sql = "SELECT COUNT(*) FROM student
            INNER JOIN privilege ON student.id = studentid
            INNER JOIN privilegedetails ON privilegeid = privilegedetails.id
            WHERE email = :email AND privilegedetails.id = :privilegeId";
        $s = $pdo->prepare($sql);
        $s->bindValue(':email', $_SESSION['email']);
        $s->bindValue(':privilegeId', $role);
        $s->execute();
    }
    catch (PDOException $e)
    {
        $error = 'Error searching for student privileges.';
        include 'error.html.php';
        exit();
    }
    
    $row = $s->fetch();
    
    if ($row[0] > 0)
    {
        return TRUE;
    }
    else
    {
       return FALSE; 
    }
}