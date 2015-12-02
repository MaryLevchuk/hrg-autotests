using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Locators
    {   
        //Menu
        public static string GetInspiredMenuItem = ".inspiration";
       
        public static string MenuPanel = ".drawer";
        public static string Logo = "#logo";
        public static string PrimaryItems = ".nav-global-primary li";
        public static string SecondaryItems = ".nav-global-secondary li";
        public static string LanguageSelector = ".global-settings-language";

        public static string ActiveMenuItem = "a.active";

        //Footer
        public static string FooterPanel = ".main-footer";
        public static string SocialIcons = "a.icon.icon-only";   
        public static string SocialIconsText = ".footer-social-media-title";
        public static string InfoList = ".footer-info-list";
        public static string Copyright = ".footer-info-copyright";
        public static string LogoListItems = ".footer-logo-list li";
        public static string ArrowUp = ".footer-back-to-top";

        //InspirationPage
        public static string FilterIconsList = ".inspiration-filter-nav-tab-icon";
        public static string FilterTitlesList = ".title";
        public static string FilterOptionsList = ".form-label.form-label-checkbox";
        public static string ClearAllFiltersBtn = ".grid-filter-clear-all";
        public static string SearchInput = ".filter-search #inspiration-search";
        public static string SearchBtn = ".filter-search-button";
        public static string ArticlesList = ".grid-item.wow.zoomIn.wow-animated.animated.animated";
        public static string FilteredArticles = ".grid-item.wow.zoomIn.wow-animated.animated.animated[style=\"visibility: visible;\"]";
        public static string ArticlesUrlsList = ".grid-item-link";

        public static string InspirationHeader = ".header-primary";
        public static string InspirationIntro = ".excerpt";
        public static string LastVisibleArticle = ".grid-item.wow.zoomIn.wow-animated.animated.animated:nth-child(5)";
        public static string ArticleBackgroundImg = ".item.active.top-image-container img";

        //RelatedInspirationArticle
        public static string ViewRelatedTravelSuggestionsLink = ".icon-right[href=\"#\"]";
        public static string RelatedArticlesList = ".grid-items.grid-items-single.grid-items-left-align.list li";

        //HomePage
        public static string BackgroudImageDiv = ".homepage-bg";
        public static string Header = ".center";
        public static string Intro = ".excerpt.inverted.step3";
        public static string FindAnAdventureBtn = ".link.step4";
        public static string PromotedTravels = ".homepage-promoted-travels";
    }
}
