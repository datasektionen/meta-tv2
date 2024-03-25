<script>
    import Slide from "$lib/Slide.svelte";
    import { State, currentTime, currentDate } from "$lib/index.js";

    export let state;
    export let title = "Title";
    export let creator = "bwidman";
    export let lastEditedBy = "";
    export let hidden = false;
    export let priority = false;
    export let neverExpire = false;
    export let startDate = currentDate();
    export let startTime = currentTime();
    export let endDate = currentDate();
    export let endTime = currentTime();
    export let archivedDate = "";
    export let slides = [1,2];

    $: startDateTime = `${startDate} ${startTime}`;
    $: endDateTime = `${endDate} ${endTime}`;

    const clickedEdit = () => {
        state = State.edit;
    };

    const clickedConfirm = () => {
        title = title.trim();
        if (title.length >= 3){
            state = State.preview;
        } else {
            alert("Title too short");
        }
    };

    const clickedPublish = () => {
        title = title.trim();
        if (title.length >= 3){
            state = State.preview;
        } else {
            alert("Title too short");
        }
    };
    
    const clickedAddSlide = () => {
        if (slides.length >= 10){
            alert("This collection already contains the maximum amount of 10 slides");
        } else {
            slides = [...slides, 1];
        }
    };

</script>

<div class="group">
    <!--HEADER-->
    <div class="flex-two-regions">
        <div>
            {#if state === State.create || state === State.edit}
                <input type="text" maxlength="35" class="title-input" bind:value={title} placeholder="Title"/>
            {:else if state === State.preview || state === State.restore}
                <h2>{title}</h2>
            {/if}
        
            <p class="gray-text">Created by: {creator}</p>
            {#if lastEditedBy.length !== 0}
                <p class="gray-text">Last edited by: {lastEditedBy}</p>
            {/if}
        </div>
        <div>
            {#if priority}
                <p>Priority</p>
            {/if}
            {#if hidden === false && state === State.preview}
                <button class="icon-button" on:click={clickedEdit}>
                    <!--Edit icon-->
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="M16.293 3.293a1 1 0 0 1 1.414 0l3 3a1 1 0 0 1 0 1.414l-9 9A1 1 0 0 1 11 17H8a1 1 0 0 1-1-1v-3a1 1 0 0 1 .293-.707zM9 13.414V15h1.586l8-8L17 5.414zM3 7a2 2 0 0 1 2-2h5a1 1 0 1 1 0 2H5v12h12v-5a1 1 0 1 1 2 0v5a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"/></svg>
                </button>
            {/if}
            {#if state === State.edit}
                <button class="icon-button">
                    <!--History icon-->
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16"><path fill-rule="evenodd" d="M4.806.665A8 8 0 1 1 .612 11.07a.75.75 0 1 1 1.385-.575A6.5 6.5 0 1 0 2.523 4.5H4.25a.75.75 0 0 1 0 1.5H0V1.75a.75.75 0 0 1 1.5 0v1.586A8 8 0 0 1 4.806.666ZM8 3a.75.75 0 0 1 .75.75v3.94l2.034 2.034a.75.75 0 1 1-1.06 1.06L7.47 8.53l-.22-.22V3.75A.75.75 0 0 1 8 3" clip-rule="evenodd"/></svg>
                </button>
                <button class="icon-button" on:click={clickedConfirm}>
                    <!--Confirm icon-->
                    <svg class="green-fill" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1600 1280"><path d="M1575 310q0 40-28 68l-724 724l-136 136q-28 28-68 28t-68-28l-136-136L53 740q-28-28-28-68t28-68l136-136q28-28 68-28t68 28l294 295l656-657q28-28 68-28t68 28l136 136q28 28 28 68"/></svg>
                </button>
            {/if}
            {#if state !== "restore"}
                <button class="icon-button">
                    <!--Trash can icon-->
                    <svg class="red-fill" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16"><path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"/></svg>
                </button>
            {/if}
        </div>
    </div>

    <!--MIDDLE-->
    {#if hidden == false || state === State.create}
        <div class="group_middle"> 
            <div class="slide-holder"> 
                {#each slides as slide}
                    <Slide />
                {:else}
                    <p>There are no slides yet</p>
                {/each}
            </div>
            {#if state === State.create || state === State.edit}
                <button id="add-slide-btn" on:click={clickedAddSlide}>
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1408 1408"><path d="M1408 608v192q0 40-28 68t-68 28H896v416q0 40-28 68t-68 28H608q-40 0-68-28t-28-68V896H96q-40 0-68-28T0 800V608q0-40 28-68t68-28h416V96q0-40 28-68t68-28h192q40 0 68 28t28 68v416h416q40 0 68 28t28 68"/></svg>
                </button>
            {/if}
        </div>
    {:else}
        <p class="gray-text">This content has been hidden</p>
    {/if}

    <!--FOOTER-->
    <div class="flex-two-regions">
        {#if state === State.create || state === State.edit}
            <div>
                <div>
                    <input type="date" bind:value={startDate}/>
                    <input type="time" bind:value={startTime}/>
                </div>

                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16"><path fill-rule="evenodd" d="M10.159 10.72a.75.75 0 1 0 1.06 1.06l3.25-3.25L15 8l-.53-.53l-3.25-3.25a.75.75 0 0 0-1.061 1.06l1.97 1.97H1.75a.75.75 0 1 0 0 1.5h10.379z" clip-rule="evenodd"/></svg>
                {#if !neverExpire}
                    <div>
                        <input type="date" bind:value={endDate}/>
                        <input type="time" bind:value={endTime}/>
                    </div>
                {/if}

                <div class="checkbox-container">
                    <label for="neverExpire">Never expire:</label>
                    <input type="checkbox" id="neverExpire" bind:checked={neverExpire}/>
                </div>
            </div>
            <div>
                <div class="checkbox-container">
                    <label for="priority">Only display this group:</label>
                    <input type="checkbox" id="priority" bind:checked={priority}/>
                </div>
                <div class="checkbox-container">
                    <label for="hidden">Hide this group:</label>
                    <input type="checkbox" id="hidden" bind:checked={hidden}/>
                </div>
            </div>
            
        {:else if state === State.preview}
            <div>
                <!--Calendar icon-->
                <svg class="black-stroke" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"><path d="M8 2v4m8-4v4"/><rect width="18" height="18" x="3" y="4" rx="2"/><path d="M3 10h18M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01"/></g></svg> 
                <p>{startDateTime}</p>
                <!--Arrow icon-->
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16"><path fill-rule="evenodd" d="M10.159 10.72a.75.75 0 1 0 1.06 1.06l3.25-3.25L15 8l-.53-.53l-3.25-3.25a.75.75 0 0 0-1.061 1.06l1.97 1.97H1.75a.75.75 0 1 0 0 1.5h10.379z" clip-rule="evenodd"/></svg>
                <!--Calendar icon-->
                <svg class="black-stroke" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"><path d="M8 2v4m8-4v4"/><rect width="18" height="18" x="3" y="4" rx="2"/><path d="M3 10h18M8 14h.01M12 14h.01M16 14h.01M8 18h.01M12 18h.01M16 18h.01"/></g></svg> 
                <p>
                    {#if neverExpire}
                        Forever
                    {:else}
                        {endDateTime}
                    {/if}
                </p>
            </div>
        {:else if state === State.restore}
            <p>Archived: {archivedDate}</p>
        {/if}
        
    </div>
    {#if state === State.create}
        <button class="publish-button" on:click={clickedPublish}>Publish</button>
    {/if}
</div>

<style>
    .group {
        padding: 1em;
        background-color: #E5E5E5;
        border-radius: 1em;
        box-shadow: 2px 2px 5px gray;
    }

    h2, p {
        display: inline;
        font-weight: 600;
        margin: 0;
    }

    .title-input {
        border: 0;
        border-radius: 0.4em;
        padding: 0.3em;
        text-align: center;
        font-size: 1.2rem;
    }

    .gray-text {
        color: gray;
    }

    .group_middle {
        margin: 1.5em 0;
        text-align: center;
    }

    .slide-holder {
       margin: 1.5em 0;
       display: flex;
       flex-direction: column;
       gap: 1em;
    }
    
    #add-slide-btn {
        width: 85%;
        background-color: var(--green);
        border: 1px solid rgba(8, 66, 15, 0.15);
        padding: 0.5em;
    }

    #add-slide-btn:hover {
        background-color: var(--green-hover);
    }

    .checkbox-container {
        display: flex;
        align-items: center;
        gap: 0.3em;
    }

    .publish-button {
        background-color: var(--green);
        border: 1px solid rgba(8, 66, 15, 0.15);
        font-weight: 600;
        float: right;
        margin-top: 2em;
    }

    .publish-button:hover {
        background-color: var(--green-hover);
    }
</style>