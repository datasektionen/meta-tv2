<header>
    <a href="/"><h1>META-TV</h1></a>
    <nav>
        <a href="/history"><svg xmlns="http://www.w3.org/2000/svg" width="2em" height="2em" viewBox="0 0 16 16"><path fill="black" fill-rule="evenodd" d="M4.806.665A8 8 0 1 1 .612 11.07a.75.75 0 1 1 1.385-.575A6.5 6.5 0 1 0 2.523 4.5H4.25a.75.75 0 0 1 0 1.5H0V1.75a.75.75 0 0 1 1.5 0v1.586A8 8 0 0 1 4.806.666ZM8 3a.75.75 0 0 1 .75.75v3.94l2.034 2.034a.75.75 0 1 1-1.06 1.06L7.47 8.53l-.22-.22V3.75A.75.75 0 0 1 8 3" clip-rule="evenodd"/></svg></a>
        <a href="/restore" class="nav-button">Restore slides</a>
        <a href="/login" class="nav-button">Log in</a>
    </nav>
</header>
<main>
    <slot />
</main>
<footer>
    <p>
        Created with passion by Avid, Benjamin, Daniel N, Daniel S,<br/>
        Dennis, Jacob, Jonathan & Ossian in PVK 2024
    </p>
</footer>

<style>
    header {
        padding: 0.2em 2em;
        box-shadow: 0 0 1em #111;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }

    nav {
        display: flex;
        align-items: center;
    }

    nav > * {
        margin: 0.5em 1em;
    }

    header a {
        text-decoration: none;
        color: black;
        display: inline-block;
    }

    .nav-button {
        padding: 0.8em 1em;
        color: white;
        background-color: #e83c84;
        border-radius: 0.5em;
    }

    footer {
        background-color: #eeeeee;
        padding: 3em 0;
    }

    footer p {
        text-align: center;
    }
</style>
