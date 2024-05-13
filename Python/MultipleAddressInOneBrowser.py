import webbrowser

# YouTube video URL'lerini bir liste içerisinde tanımlayın
youtube_urls = [
    'https://dev.azure.com/barutus/DevOpsDemo/_apps/hub/ms.vss-build-web.ci-designer-hub?pipelineId=21&branch=main',
    'https://dev.azure.com/barutus/DevOpsDemo/_git/DevOpsDemo-2?path=/Source/Program.cs',
    'https://dev.azure.com/barutus/DevOpsDemo/_build/results?buildId=268&view=logs&j=12f1170f-54f2-53f3-20dd-22fc7dff55f9&t=f8ed7bd8-2a7f-56f6-9385-7fc29a8b5b7b',
    'https://openai.com/product',
    'https://platform.openai.com/docs/assistants/tools',
    'https://platform.openai.com/docs/guides/images/usage?context=node&lang=curl',
    'https://www.youtube.com/results?search_query=use+dapr+for+microservices',
    'https://www.youtube.com/watch?v=mBgQBMhboyU&t=15s',
    'https://microsoft.sharepoint.com/teams/MCAPSAcademy/SitePages/Build-your-expertise.aspx',
    'https://microsoft.sharepoint.com/teams/MCAPSAcademy/SitePages/Career-Explorer.aspx',
    'https://learn.microsoft.com/en-us/credentials/certifications/azure-ai-fundamentals/',
    'https://microsoft.sharepoint.com/:p:/t/CodeWithCSU/EWnRb-mDo45Bg7ZxZANHKZwBiwfPMdwpWJuHDbQkviNEpA?e=5zuKJb'

    # daha fazla URL ekleyebilirsiniz
]

# Her bir URL'yi yeni bir sekmede açın
for url in youtube_urls:
    webbrowser.open_new_tab(url)