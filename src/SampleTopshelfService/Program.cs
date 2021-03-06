﻿// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace SampleTopshelfService
{
    using Topshelf;

    class Program
    {
        static void Main()
        {
            HostFactory.Run(x => x.Service<SampleService>());
        }

        void SansInterface()
        {
            HostFactory.New(x =>
                {
                    // can define services without the interface dependency as well, this is just for
                    // show and not used in this sample.
                    x.Service<SampleSansInterfaceService>(s =>
                        {
                            s.ConstructUsing(() => new SampleSansInterfaceService());
                            s.WhenStarted(v => v.Start());
                            s.WhenStarted(v => v.Stop());
                        });
                });
        }
    }
}