using AngleSharp;
using AngleSharp.Dom;
using ESOF.WebApp.WebAPI.DtoClasses;
using Microsoft.EntityFrameworkCore;

namespace ESOF.WebApp.WebAPI.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.DBLayer.Context;

public class ScrapingService
{
    private readonly ApplicationDbContext _context;
    private readonly IBrowsingContext _browsingContext;

    public ScrapingService(ApplicationDbContext context)
    {
        _context = context;
        _browsingContext = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
    }

    public async Task<List<ScrapedWineDto>> GetAllWines()
    {
        return await _context.ScrapedWines
            .OrderByDescending(wine => wine.CreatedAt)
            .Select(wine => new ScrapedWineDto()
            {
                ScrapedWineId = wine.ScrapedWineId,
                Url = wine.Url,
                Label = wine.Label,
                CreatedAt = wine.CreatedAt,
            }).ToListAsync();
    }

    public async Task<ScrapedWineDto> CreateWine(ScrapingRequestDto request)
    {
        var uri = new Uri(request.Url);
        var wine = await ScrapeWine(uri);

        var wineEntry = await _context.ScrapedWines.AddAsync(wine);
        await _context.SaveChangesAsync();
        return new ScrapedWineDto()
        {
            ScrapedWineId = wineEntry.Entity.ScrapedWineId,
            Url = wineEntry.Entity.Url,
            Label = wineEntry.Entity.Label,
            CreatedAt = wineEntry.Entity.CreatedAt
        };
    }

    public async Task DeleteWine(Guid wineId)
    {
        var wine = await _context.ScrapedWines.FindAsync(wineId);
        _context.ScrapedWines.Remove(wine);
        await _context.SaveChangesAsync();
    }

    private async Task<ScrapedWine> ScrapeWine(Uri uri)
    {
        return uri.Host switch
        {
            "www.garrafeiranacional.com" => await ScrapeWine_www_garrafeiranacional_com(uri),
            "infovini.com" => await ScrapeWine_infovini_com(uri),
            "www.lojadovinho.com" => await ScrapeWine_www_lojadovinho_com(uri),
            "www.vinhedo.pt" => await ScrapeWine_www_vinhedo_pt(uri),
            "wine.pt" => await ScrapeWine_wine_pt(uri),
            "winestuff.pt" => await ScrapeWine_winestuff_pt(uri),
            _ => throw new ArgumentException("unsupported website"),
        };
    }

    private async Task<ScrapedWine> ScrapeWine_www_garrafeiranacional_com(Uri uri)
    {
        var document = await _browsingContext.OpenAsync(uri.AbsoluteUri);
        var labelSelector =
            "#maincontent > div.columns > div > div.prod_detail_section > div.prod_detail_part1 > div.product-info-main.col-md-6.col-sm-6.col-xs-12.right_column > div.page-title-wrapper.prod_name > h1 > span";
        var labelElement = document.QuerySelector(labelSelector);
        return new ScrapedWine()
        {
            Url = uri.AbsoluteUri,
            Label = labelElement!.Text(),
        };
    }

    private async Task<ScrapedWine> ScrapeWine_infovini_com(Uri uri)
    {
        var document = await _browsingContext.OpenAsync(uri.AbsoluteUri);
        var labelSelector = "#fichaVinho > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2)";
        var labelElement = document.QuerySelector(labelSelector);
        return new ScrapedWine()
        {
            Url = uri.AbsoluteUri,
            Label = labelElement!.Text(),
        };
    }

    private async Task<ScrapedWine> ScrapeWine_www_lojadovinho_com(Uri uri)
    {
        var document = await _browsingContext.OpenAsync(uri.AbsoluteUri);
        var labelSelector =
            "#wrap-content > div.content-main > div > div > div.product-info1 > div.product-description > h1";
        var labelElement = document.QuerySelector(labelSelector);
        return new ScrapedWine()
        {
            Url = uri.AbsoluteUri,
            Label = labelElement!.Text(),
        };
    }

    private async Task<ScrapedWine> ScrapeWine_www_vinhedo_pt(Uri uri)
    {
        var document = await _browsingContext.OpenAsync(uri.AbsoluteUri);
        var labelSelector = ".woo_c-product-details-title";
        var labelElement = document.QuerySelector(labelSelector);
        return new ScrapedWine()
        {
            Url = uri.AbsoluteUri,
            Label = labelElement!.Text(),
        };
    }

    private async Task<ScrapedWine> ScrapeWine_wine_pt(Uri uri)
    {
        var document = await _browsingContext.OpenAsync(uri.AbsoluteUri);
        var labelSelector =
            "#ProductSection-product-template > div > div > div > div.product-shop.col-md-6.left-vertical-moreview.vertical-moreview > h1 > span";
        var labelElement = document.QuerySelector(labelSelector);
        return new ScrapedWine()
        {
            Url = uri.AbsoluteUri,
            Label = labelElement!.Text(),
        };
    }

    private async Task<ScrapedWine> ScrapeWine_winestuff_pt(Uri uri)
    {
        var document = await _browsingContext.OpenAsync(uri.AbsoluteUri);
        var labelSelector = ".product-details-product-title";
        var labelElement = document.QuerySelector(labelSelector);
        return new ScrapedWine()
        {
            Url = uri.AbsoluteUri,
            Label = labelElement!.Text(),
        };
    }
}
