<header>
    <a href="/"><h1>META-TV</h1></a>
    <nav>
        <a href="/history">History</a>
        <a href="/restore">Restore slides</a>
        <a href="/login">Log in</a>
    </nav>
</header>
<main>
    <slot />
</main>
<footer>
    <p>
        Created with passion by Avid, Benjamin, Daniel N, Daniel S, Dennis,
        Jacob, Jonathan & Ossian in PVK 2024
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

    header a {
        text-decoration: none;
        color: black;
        display: inline-block;
    }

    nav a {
        margin: 0.5em 1em;
        padding: 1em 1.5em;
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
