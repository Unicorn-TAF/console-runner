﻿namespace Unicorn.ConsoleRunner
{
    internal static class ResourceAsciiLogo
    {
        private const string LogoImage = @"
                     _,yp@@@55@@@%yy,,                              
                  ,#@5555555555555555}}@Fy,,,,,,                    
               ,@@@555555555555555@^555}}}}5F`                      
             ,@@@@@@555555555555F`,@555G,,_                         
            @@@@@@@@@555555555F  /5555555}}}5@Vy,,_                 
          ,@@@@@@@@@@@@5@55@`   {555555555}}}!!!!!!!5}5+==          
          @@@@@@@@F'`    F     @55555555555}}}!}!!!!!!!y,,,,,,,,,,,-
         @@@@@@F             ,@5555555555555}}}}}}!!!!!!!!!!!!!!!!! 
        |@@@@^               T@555555555555555}}}}!!!!!!!!!!!!!!!F  
        |@@F           ,pWy    `%55555555555555}}!!!!!!!!!!!!!!F    
        @@F                       '$55555555555}}}}}!!!!!!!!!F`     
        |F       {L                  '@555555555}}}}}!!!!!!F        
        |        !!                    '55555555555}}}!!F`          
                 !!!%,                  55555555555}8'`             
                 !!!!!!!{@@@Wpwwy,,,_,a@55555555F^`      ,,         
                 {!!!!!!!@@@@@@@@@@@5555555555555@@#w#@@}'          
                  }!!!!!!@@@@@@@@@@@5555555555555555555F            
                  `5!!!!!@@@@@@@@@@@@@55555555555555@`              
                    T!!!!|@@@@@@@@@@@@@5555555555@F                 
                      '5!!!|@@@@@@@@@@@@555555N'                    
                        `'T!|$@@@@@@@@@@@@F^`                       
                              `'''^'^`                              ";


        private const string LogoText = @"
y     y_         y,                                   yyyyyyy  ,y,    ,yyyyy,
@     @L .,,,_   ,_   ,,_     ,~,,     ,~_  .,,_        |@     @E@L   j@     
@     @L @@^'$@  @L @B^'^%' {@^`'$@_ |@^`` |@F'^@L      |@    |@ |@   j@,,,  
@     @L @L   @L @L|@      |@     |@ |@    |@   |@      |$   ;$G%P$@  j@```   
$@,_,{@  @L   @L @L`$W,_,w, $W,_,a@` |@    |$   |@ ,    |$  ,@F    $b j@     
  '^^`   ^    ^  ^   `'^^`    `^^`   ``    `^   `^ '    `^  `^     `^ `^     ";

        internal const string Logo = LogoImage + "\n" + LogoText;
    }
}